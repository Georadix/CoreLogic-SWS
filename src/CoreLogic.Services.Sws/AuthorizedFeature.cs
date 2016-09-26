namespace CoreLogic.Services.Sws
{
    /// <summary>
    /// Represents information about features accessible to an SWS account.
    /// </summary>
    public class AuthorizedFeature
    {
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }
    }
}