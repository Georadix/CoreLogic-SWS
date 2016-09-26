namespace CoreLogic.Services.Sws
{
    /// <summary>
    /// Represents a response to a SpatialRecord request.
    /// </summary>
    public class SpatialRecordResponse
    {
        /// <summary>
        /// Gets or sets the page information.
        /// </summary>
        public PageInfo PageInfo { get; set; }

        /// <summary>
        /// Gets or sets the parcels.
        /// </summary>
        public SpatialRecordParcel[] Parcels { get; set; }
    }
}