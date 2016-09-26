namespace CoreLogic.Services.Sws
{
    /// <summary>
    /// Represents a response to a get authorized features request.
    /// </summary>
    public class AuthorizedFeaturesResponse
    {
        /// <summary>
        /// Gets or sets the collection of authorized features.
        /// </summary>
        public AuthorizedFeature[] Features { get; set; }

        /// <summary>
        /// Gets or sets the collection of authorized operations.
        /// </summary>
        public AuthorizedOperation[] Operations { get; set; }
    }
}