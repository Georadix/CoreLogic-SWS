namespace CoreLogic.Services.Sws
{
    /// <summary>
    /// Represents a response to a PxPoint geocode request.
    /// </summary>
    public class PxPointGeocodeResponse
    {
        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        public PxPointGeocodeResult Location { get; set; }
    }
}