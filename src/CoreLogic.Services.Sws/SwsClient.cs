﻿namespace CoreLogic.Services.Sws
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a client used to communicate with CoreLogic's Spatial Web Services (SWS).
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SwsClient : ISwsClient, IDisposable
    {
        private readonly ISwsConfig config;
        private readonly JsonMediaTypeFormatter formatter;
        private readonly HttpClient httpClient;
        private readonly object syncRoot = new object();
        private string authKey;
        private DateTime authKeyTimestamp;
        private bool disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="SwsClient"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <exception cref="ArgumentNullException"><paramref name="config" /> is <see langword="null" />.</exception>
        public SwsClient(ISwsConfig config)
        {
            config.AssertNotNull("config");

            this.config = config;

            this.formatter = new JsonMediaTypeFormatter();
            this.formatter.SerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            this.httpClient = HttpClientFactory.Create(new SwsErrorHandler());
            this.httpClient.BaseAddress = new Uri(this.config.EndpointUrl);
            this.httpClient.Timeout = TimeSpan.FromSeconds(this.config.Timeout);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="SwsClient"/> class.
        /// </summary>
        ~SwsClient()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Gets the spatial record parcel count within a specified polygon.
        /// </summary>
        /// <param name="polygonWkt">The polygon, in well-known text (WKT) format.</param>
        /// <param name="bundle">The bundle.</param>
        /// <returns>The number of parcels within the specified polygon.</returns>
        public int GetSpatialRecordParcelCount(
            string polygonWkt, SpatialRecordBundle bundle = SpatialRecordBundle.SpatialRecordOGPremium)
        {
            this.EnsureValidAuthKey();

            var content = new SpatialRecordPolygonRequest(this.authKey, polygonWkt, 1, 1, bundle);

            var request = this.CreateSpatialRecordTask(HttpMethod.Post, content);
            request.Wait();

            var response = request.Result.Content.ReadAsAsync<SpatialRecordResponse>();
            response.Wait();

            return response.Result.PageInfo.Length;
        }

        /// <summary>
        /// Gets the parcels within a specified polygon.
        /// </summary>
        /// <param name="polygonWkt">The polygon, in well-known text (WKT) format.</param>
        /// <param name="bundle">The bundle.</param>
        /// <returns>An array of <see cref="SpatialRecordParcel"/> instances.</returns>
        public SpatialRecordParcel[] GetSpatialRecordParcels(
            string polygonWkt, SpatialRecordBundle bundle = SpatialRecordBundle.SpatialRecordOGPremium)
        {
            return this.GetSpatialRecordParcels(
                HttpMethod.Post,
                (authKey, pageNumber) => new SpatialRecordPolygonRequest(authKey, polygonWkt, pageNumber, 50, bundle));
        }

        /// <summary>
        /// Gets the parcels at a specified latitude/longitude.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="bundle">The bundle.</param>
        /// <returns>An array of <see cref="SpatialRecordParcel"/> instances.</returns>
        public SpatialRecordParcel[] GetSpatialRecordParcels(
            double latitude, double longitude, SpatialRecordBundle bundle = SpatialRecordBundle.SpatialRecordOGPremium)
        {
            return this.GetSpatialRecordParcels(
                HttpMethod.Get,
                (authKey, pageNumber) =>
                    new SpatialRecordLatLongRequest(authKey, latitude, longitude, pageNumber, 50, bundle));
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">
        /// <c>true</c> to release both managed and unmanaged resources;
        /// <c>false</c> to release only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.httpClient.Dispose();
                }

                this.disposed = true;
            }
        }

        private string Authenticate()
        {
            var request = this.httpClient.PostAsync(
                "authenticate",
                new AuthRequest { Password = this.config.Password, Username = this.config.Username },
                this.formatter);
            request.Wait();

            var response = request.Result.Content.ReadAsAsync<AuthResponse>();
            response.Wait();

            return response.Result.AuthKey;
        }

        private Task<HttpResponseMessage> CreateSpatialRecordTask(HttpMethod method, SpatialRecordRequest request)
        {
            var url = "parcels";

            return (method == HttpMethod.Post) ?
                this.httpClient.PostAsync(url, request, this.formatter) :
                this.httpClient.GetAsync(string.Format("{0}?{1}", url, request.ToQueryString()));
        }

        private void EnsureValidAuthKey()
        {
            lock (this.syncRoot)
            {
                if (string.IsNullOrWhiteSpace(this.authKey) ||
                    (this.authKeyTimestamp < DateTime.UtcNow.AddMinutes(-50)))
                {
                    this.authKey = this.Authenticate();
                    this.authKeyTimestamp = DateTime.UtcNow;
                }
            }
        }

        private SpatialRecordParcel[] GetSpatialRecordParcels(
            HttpMethod method, Func<string, int, SpatialRecordRequest> factory)
        {
            this.EnsureValidAuthKey();

            var content = factory(this.authKey, 1);

            var request = this.CreateSpatialRecordTask(method, content);
            request.Wait();

            var response = request.Result.Content.ReadAsAsync<SpatialRecordResponse>();
            response.Wait();

            var parcels = new List<SpatialRecordParcel>(response.Result.Parcels);
            var pageInfo = response.Result.PageInfo;
            var numberOfExtraPages = Math.Ceiling(pageInfo.Length / (double)pageInfo.PageSize) - 1;

            if (numberOfExtraPages > 0)
            {
                var completedTasks = new List<Task<HttpResponseMessage>>();

                for (var i = 0; i <= Math.Ceiling(numberOfExtraPages / 10.0) - 1; i++)
                {
                    var tasks = new List<Task<HttpResponseMessage>>();

                    for (var j = 2 + (i * 10); j <= Math.Min(11 + (i * 10), numberOfExtraPages + 1); j++)
                    {
                        var followUpContent = factory(this.authKey, j);
                        tasks.Add(this.CreateSpatialRecordTask(method, followUpContent));
                    }

                    Task.WaitAll(tasks.ToArray());

                    completedTasks.AddRange(tasks);
                }

                foreach (var task in completedTasks)
                {
                    var taskResponse = task.Result.Content.ReadAsAsync<SpatialRecordResponse>();
                    taskResponse.Wait();

                    parcels.AddRange(taskResponse.Result.Parcels);
                }
            }

            return parcels.ToArray();
        }
    }
}