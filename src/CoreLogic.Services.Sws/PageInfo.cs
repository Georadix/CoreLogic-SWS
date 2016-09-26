namespace CoreLogic.Services.Sws
{
    /// <summary>
    /// Represents the page information.
    /// </summary>
    public class PageInfo
    {
        /// <summary>
        /// Gets or sets the actual page size.
        /// </summary>
        public int ActualPageSize { get; set; }

        /// <summary>
        /// Gets or sets the length.
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Gets or sets the maximum page size.
        /// </summary>
        public int MaxPageSize { get; set; }

        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the page size.
        /// </summary>
        public int PageSize { get; set; }
    }
}