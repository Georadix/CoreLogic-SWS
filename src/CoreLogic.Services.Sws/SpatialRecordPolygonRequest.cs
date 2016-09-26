namespace CoreLogic.Services.Sws
{
    using System.Web;

    /// <summary>
    /// Represents a SpatialRecord request using a polygon.
    /// </summary>
    public class SpatialRecordPolygonRequest : SpatialRecordRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpatialRecordPolygonRequest"/> class.
        /// </summary>
        /// <param name="authKey">The authentication key.</param>
        /// <param name="geometry">The polygon in well-known text (WKT) format.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="bundle">The bundle.</param>
        public SpatialRecordPolygonRequest(
            string authKey,
            string geometry,
            int pageNumber = 1,
            int pageSize = 50,
            SpatialRecordBundle bundle = SpatialRecordBundle.SpatialRecordOGPremium)
            : base(authKey, pageNumber, pageSize, bundle)
        {
            this.Geometry = geometry;
        }

        /// <summary>
        /// Gets or sets the polygon in well-known text (WKT) format.
        /// </summary>
        public string Geometry { get; set; }

        /// <summary>
        /// Returns the query string representation of the current request.
        /// </summary>
        /// <returns>The query string representation of the current request.</returns>
        public override string ToQueryString()
        {
            var query = HttpUtility.ParseQueryString(base.ToQueryString());

            query.Add("geometry", this.Geometry);

            return query.ToString();
        }
    }
}