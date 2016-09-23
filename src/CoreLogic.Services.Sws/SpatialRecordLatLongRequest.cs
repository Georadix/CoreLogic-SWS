namespace CoreLogic.Services.Sws
{
    using System.Web;

    /// <summary>
    /// Represents a SpatialRecord request using a latitude and longitude.
    /// </summary>
    public class SpatialRecordLatLongRequest : SpatialRecordRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpatialRecordLatLongRequest"/> class.
        /// </summary>
        /// <param name="authKey">The authentication key.</param>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="bundle">The bundle.</param>
        public SpatialRecordLatLongRequest(
            string authKey,
            double latitude,
            double longitude,
            int pageNumber = 1,
            int pageSize = 50,
            SpatialRecordBundle bundle = SpatialRecordBundle.SpatialRecordOGPremium)
            : base(authKey, pageNumber, pageSize, bundle)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Returns the query string representation of the current request.
        /// </summary>
        /// <returns>The query string representation of the current request.</returns>
        public override string ToQueryString()
        {
            var query = HttpUtility.ParseQueryString(base.ToQueryString());

            query.Add("lat", this.Latitude.ToString());
            query.Add("lon", this.Longitude.ToString());

            return query.ToString();
        }
    }
}