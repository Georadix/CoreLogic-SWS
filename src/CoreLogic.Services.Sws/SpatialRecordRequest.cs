namespace CoreLogic.Services.Sws
{
    using System.Web;

    /// <summary>
    /// Represents a SpatialRecord request.
    /// </summary>
    public abstract class SpatialRecordRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpatialRecordRequest"/> class.
        /// </summary>
        /// <param name="authKey">The authentication key.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="bundle">The bundle.</param>
        protected SpatialRecordRequest(
            string authKey,
            int pageNumber = 1,
            int pageSize = 50,
            SpatialRecordBundle bundle = SpatialRecordBundle.SpatialRecordOGPremium)
        {
            this.AuthKey = authKey;
            this.Bundle = bundle.ToString();
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
        }

        /// <summary>
        /// Gets or sets the authentication key.
        /// </summary>
        public string AuthKey { get; set; }

        /// <summary>
        /// Gets or sets the bundle.
        /// </summary>
        public string Bundle { get; set; }

        /// <summary>
        /// Gets or sets the page number.
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the page size (i.e. 1-50).
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Returns the query string representation of the current request.
        /// </summary>
        /// <returns>The query string representation of the current request.</returns>
        public virtual string ToQueryString()
        {
            var query = HttpUtility.ParseQueryString(string.Empty);

            query.Add("pageNumber", this.PageNumber.ToString());
            query.Add("pageSize", this.PageSize.ToString());
            query.Add("bundle", this.Bundle);
            query.Add("authKey", this.AuthKey);

            return query.ToString();
        }
    }
}