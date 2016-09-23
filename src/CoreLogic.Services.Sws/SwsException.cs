namespace CoreLogic.Services.Sws
{
    using System;
    using System.Net.Http;
    using System.Runtime.Serialization;
    using System.Text;

    /// <summary>
    /// Represents errors that occur while processing HTTP requests to CoreLogic's Spatial Web Services (SWS).
    /// </summary>
    [Serializable]
    public class SwsException : Exception
    {
        private readonly HttpRequestMessage request;
        private readonly HttpResponseMessage response;

        /// <summary>
        /// Initializes a new instance of the <see cref="SwsException"/> class.
        /// </summary>
        public SwsException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SwsException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public SwsException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SwsException"/> class with a specified error message and a
        /// reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception, or <see langword="null"/> if no inner exception
        /// is specified.
        /// </param>
        public SwsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SwsException"/> class with a specified error message, request
        /// message, and response message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="request">The request message.</param>
        /// <param name="response">The response message.</param>
        public SwsException(string message, HttpRequestMessage request, HttpResponseMessage response)
            : this(message)
        {
            this.request = request;
            this.response = response;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SwsException"/> class with a specified error message, request
        /// message, response message, and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="request">The request message.</param>
        /// <param name="response">The response message.</param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception, or <see langword="null"/> if no inner exception
        /// is specified.
        /// </param>
        public SwsException(
            string message, HttpRequestMessage request, HttpResponseMessage response, Exception innerException)
            : this(message, innerException)
        {
            this.request = request;
            this.response = response;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SwsException"/> class with serialized data.
        /// </summary>
        /// <param name="info">
        /// The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        /// The <see cref="StreamingContext"/> that contains contextual information about the source or destination.
        /// </param>
        protected SwsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.request = (HttpRequestMessage)info.GetValue("Request", typeof(HttpRequestMessage));
            this.response = (HttpResponseMessage)info.GetValue("Response", typeof(HttpResponseMessage));
        }

        /// <summary>
        /// Gets the request message.
        /// </summary>
        public HttpRequestMessage Request
        {
            get { return this.request; }
        }

        /// <summary>
        /// Gets the response message.
        /// </summary>
        public HttpResponseMessage Response
        {
            get { return this.response; }
        }

        /// <summary>
        /// When overridden in a derived class, sets the <see cref="SerializationInfo"/> with information about the
        /// exception.
        /// </summary>
        /// <param name="info">
        /// The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.
        /// </param>
        /// <param name="context">
        /// The <see cref="StreamingContext"/> that contains contextual information about the source or destination.
        /// </param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue("Request", this.request);
            info.AddValue("Response", this.response);
        }

        /// <summary>
        /// Returns a <see cref="String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            var builder = new StringBuilder(base.ToString());

            if (this.request != null)
            {
                builder.AppendLine().AppendLine("Request:").Append(this.request);
            }

            if (this.response != null)
            {
                builder.AppendLine().AppendLine("Response:").Append(this.response);
            }

            return builder.ToString();
        }
    }
}