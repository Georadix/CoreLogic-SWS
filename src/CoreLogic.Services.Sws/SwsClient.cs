namespace CoreLogic.Services.Sws
{
    using GeoAPI.Geometries;
    using NetTopologySuite.IO;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Threading.Tasks;
    using System.Web;

    /// <summary>
    /// Represents a client used to communicate with CoreLogic Spatial Web Services (SWS).
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SwsClient : ISwsClient, IDisposable
    {
        // Padded bounding boxes of Idaho + Montana and Kansas.
        private static string nonSolicitationAreaWkt = "MULTIPOLYGON(((" +
            "-117.390593 49.16172, -103.71802 49.16172, -103.71802 41.767646, -117.390593 41.767646, -117.390593 49.161720"
            + ")), ((" +
            "-102.249155 40.103545, -94.462404 40.103545, -94.462404 36.883405, -102.249155 36.883405, -102.249155 40.103545"
            + ")))";

        private static string[] nonSolicitationStateCodes = new string[] { "KS", "ID", "MT" };

        private readonly ISwsConfig config;
        private readonly JsonMediaTypeFormatter formatter;
        private readonly HttpClient httpClient;
        private readonly IGeometry nonSolicitationArea;
        private readonly object syncRoot = new object();
        private readonly WKTReader wktReader;
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

            this.wktReader = new WKTReader();
            this.wktReader.DefaultSRID = 4326;

            if (string.IsNullOrWhiteSpace(this.config.NonSolicitationAreaWkt))
            {
                this.nonSolicitationArea = this.wktReader.Read(nonSolicitationAreaWkt);
            }
            else
            {
                this.nonSolicitationArea = this.wktReader.Read(this.config.NonSolicitationAreaWkt);
            }
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
        /// Geocodes the specified address.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns>A <see cref="PxPointGeocodeResult"/> instance.</returns>
        public PxPointGeocodeResult Geocode(string address)
        {
            this.EnsureValidAuthKey();

            return this.Geocode(this.authKey, address);
        }

        /// <summary>
        /// Geocodes the specified address.
        /// </summary>
        /// <param name="authKey">The authentication key to access SWS.</param>
        /// <param name="address">The address.</param>
        /// <returns>A <see cref="PxPointGeocodeResult"/> instance.</returns>
        public PxPointGeocodeResult Geocode(string authKey, string address)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);

            query.Add("address", address);
            query.Add("full", "false");
            query.Add("authKey", authKey);

            var request = this.httpClient.GetAsync("geocode?" + query.ToString());
            request.Wait();

            var response = request.Result.Content.ReadAsAsync<PxPointGeocodeResponse>();
            response.Wait();

            return response.Result.Location;
        }

        /// <summary>
        /// Gets the authorized features and operations accessible to the current SWS account.
        /// </summary>
        /// <returns>An <see cref="AuthorizedFeaturesResponse"/> instance.</returns>
        public AuthorizedFeaturesResponse GetAuthorizedFeatures()
        {
            this.EnsureValidAuthKey();

            return this.GetAuthorizedFeatures(this.authKey);
        }

        /// <summary>
        /// Gets the authorized features and operations accessible to the current SWS account.
        /// </summary>
        /// <param name="authKey">The authentication key to access SWS.</param>
        /// <returns>An <see cref="AuthorizedFeaturesResponse"/> instance.</returns>
        public AuthorizedFeaturesResponse GetAuthorizedFeatures(string authKey)
        {
            var request = this.httpClient.GetAsync("features?authKey=" + authKey);
            request.Wait();

            var response = request.Result.Content.ReadAsAsync<AuthorizedFeaturesResponse>();
            response.Wait();

            return response.Result;
        }

        /// <summary>
        /// Gets the spatial record parcel count within a specified polygon.
        /// </summary>
        /// <param name="polygonWkt">The polygon, in well-known text (WKT) format.</param>
        /// <param name="bundle">The bundle.</param>
        /// <param name="excludeNonSolicitationStates">
        /// Exclude parcels in states in which owner cannot be solicited.
        /// </param>
        /// <returns>The number of parcels within the specified polygon.</returns>
        public int GetSpatialRecordParcelCount(
            string polygonWkt,
            SpatialRecordBundle bundle = SpatialRecordBundle.SpatialRecordOGPremium,
            bool excludeNonSolicitationStates = false)
        {
            this.EnsureValidAuthKey();

            return this.GetSpatialRecordParcelCount(this.authKey, polygonWkt, bundle, excludeNonSolicitationStates);
        }

        /// <summary>
        /// Gets the spatial record parcel count within a specified polygon.
        /// </summary>
        /// <param name="authKey">The authentication key to access SWS.</param>
        /// <param name="polygonWkt">The polygon, in well-known text (WKT) format.</param>
        /// <param name="bundle">The bundle.</param>
        /// <param name="excludeNonSolicitationStates">
        /// Exclude parcels in states in which owner cannot be solicited.
        /// </param>
        /// <returns>The number of parcels within the specified polygon.</returns>
        public int GetSpatialRecordParcelCount(
            string authKey,
            string polygonWkt,
            SpatialRecordBundle bundle = SpatialRecordBundle.SpatialRecordOGPremium,
            bool excludeNonSolicitationStates = false)
        {
            var polygon = this.wktReader.Read(polygonWkt);

            if (excludeNonSolicitationStates && this.nonSolicitationArea.Intersects(polygon))
            {
                return this.GetSpatialRecordParcels(polygonWkt, bundle, true).Length;
            }
            else
            {
                var content = new SpatialRecordPolygonRequest(authKey, polygonWkt, 1, 1, bundle);

                var request = this.CreateSpatialRecordTask(HttpMethod.Post, content);
                request.Wait();

                var response = request.Result.Content.ReadAsAsync<SpatialRecordResponse>();
                response.Wait();

                return response.Result.PageInfo.Length;
            }
        }

        /// <summary>
        /// Gets the parcels within a specified polygon.
        /// </summary>
        /// <param name="authKey">The authentication key to access SWS.</param>
        /// <param name="polygonWkt">The polygon, in well-known text (WKT) format.</param>
        /// <param name="bundle">The bundle.</param>
        /// <param name="excludeNonSolicitationStates">
        /// Exclude parcels in states in which owner cannot be solicited.
        /// </param>
        /// <returns>An array of <see cref="SpatialRecordParcel"/> instances.</returns>
        public SpatialRecordParcel[] GetSpatialRecordParcels(
            string authKey,
            string polygonWkt,
            SpatialRecordBundle bundle = SpatialRecordBundle.SpatialRecordOGPremium,
            bool excludeNonSolicitationStates = false)
        {
            return this.GetSpatialRecordParcels(
                this.authKey,
                HttpMethod.Post,
                (key, pageNumber) => new SpatialRecordPolygonRequest(key, polygonWkt, pageNumber, 50, bundle),
                excludeNonSolicitationStates);
        }

        /// <summary>
        /// Gets the parcels within a specified polygon.
        /// </summary>
        /// <param name="polygonWkt">The polygon, in well-known text (WKT) format.</param>
        /// <param name="bundle">The bundle.</param>
        /// <param name="excludeNonSolicitationStates">
        /// Exclude parcels in states in which owner cannot be solicited.
        /// </param>
        /// <returns>An array of <see cref="SpatialRecordParcel"/> instances.</returns>
        public SpatialRecordParcel[] GetSpatialRecordParcels(
            string polygonWkt,
            SpatialRecordBundle bundle = SpatialRecordBundle.SpatialRecordOGPremium,
            bool excludeNonSolicitationStates = false)
        {
            this.EnsureValidAuthKey();

            return this.GetSpatialRecordParcels(this.authKey, polygonWkt, bundle, excludeNonSolicitationStates);
        }

        /// <summary>
        /// Gets the parcels at a specified latitude/longitude.
        /// </summary>
        /// <param name="authKey">The authentication key to access SWS.</param>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="bundle">The bundle.</param>
        /// <param name="excludeNonSolicitationStates">
        /// Exclude parcels in states in which owner cannot be solicited.
        /// </param>
        /// <returns>An array of <see cref="SpatialRecordParcel"/> instances.</returns>
        public SpatialRecordParcel[] GetSpatialRecordParcels(
            string authKey,
            double latitude,
            double longitude,
            SpatialRecordBundle bundle = SpatialRecordBundle.SpatialRecordOGPremium,
            bool excludeNonSolicitationStates = false)
        {
            return this.GetSpatialRecordParcels(
                authKey,
                HttpMethod.Get,
                (key, pageNumber) => new SpatialRecordLatLongRequest(key, latitude, longitude, pageNumber, 50, bundle),
                excludeNonSolicitationStates);
        }

        /// <summary>
        /// Gets the parcels at a specified latitude/longitude.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="bundle">The bundle.</param>
        /// <param name="excludeNonSolicitationStates">
        /// Exclude parcels in states in which owner cannot be solicited.
        /// </param>
        /// <returns>An array of <see cref="SpatialRecordParcel"/> instances.</returns>
        public SpatialRecordParcel[] GetSpatialRecordParcels(
            double latitude,
            double longitude,
            SpatialRecordBundle bundle = SpatialRecordBundle.SpatialRecordOGPremium,
            bool excludeNonSolicitationStates = false)
        {
            this.EnsureValidAuthKey();

            return this.GetSpatialRecordParcels(
                this.authKey, latitude, longitude, bundle, excludeNonSolicitationStates);
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
            string authKey,
            HttpMethod method,
            Func<string, int, SpatialRecordRequest> factory,
            bool excludeNonSolicitationStates)
        {
            var content = factory(authKey, 1);

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
                        var followUpContent = factory(authKey, j);
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

            if (excludeNonSolicitationStates)
            {
                return parcels.Where(p => !nonSolicitationStateCodes.Contains(p.State.ToUpper())).ToArray();
            }

            return parcels.ToArray();
        }
    }
}