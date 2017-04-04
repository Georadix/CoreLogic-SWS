namespace CoreLogic.Services.Sws
{
    /// <summary>
    /// Defines the configuration for CoreLogic's Spatial Web Services (SWS).
    /// </summary>
    public interface ISwsConfig
    {
        /// <summary>
        /// Gets the endpoint URL.
        /// </summary>
        string EndpointUrl { get; }

        /// <summary>
        /// Gets the non solicitation area in well-known text (WKT).
        /// </summary>
        string NonSolicitationAreaWkt { get; }

        /// <summary>
        /// Gets the password.
        /// </summary>
        string Password { get; }

        /// <summary>
        /// Gets the number of seconds to wait before a request times out.
        /// </summary>
        int Timeout { get; }

        /// <summary>
        /// Gets the username.
        /// </summary>
        string Username { get; }
    }
}