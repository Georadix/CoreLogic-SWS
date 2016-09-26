namespace CoreLogic.Services.Sws
{
    /// <summary>
    /// Represents information about an operation accessible to an SWS account.
    /// </summary>
    public class AuthorizedOperation
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