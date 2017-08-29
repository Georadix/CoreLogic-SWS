﻿namespace CoreLogic.Services.Sws
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// A handler that throws exceptions for unsuccessful requests to CoreLogic Spatial Web Services (SWS).
    /// </summary>
    public class SwsErrorHandler : DelegatingHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwsErrorHandler"/> class.
        /// </summary>
        public SwsErrorHandler()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SwsErrorHandler"/> class with a specific inner handler.
        /// </summary>
        /// <param name="innerHandler">
        /// The inner handler which is responsible for processing the HTTP response messages.
        /// </param>
        public SwsErrorHandler(HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
        }

        /// <summary>
        /// Sends an HTTP request to the inner handler to send to the server as an asynchronous operation.
        /// </summary>
        /// <param name="request">The HTTP request message to send to the server.</param>
        /// <param name="cancellationToken">A cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken)
                .ConfigureAwait(continueOnCapturedContext: false);

            if (!response.IsSuccessStatusCode)
            {
                throw new SwsException(
                    string.Format("{0} ({1})", response.ReasonPhrase, (int)response.StatusCode),
                    response);
            }

            return response;
        }
    }
}