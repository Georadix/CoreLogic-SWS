namespace CoreLogic.Services.Sws
{
    /// <summary>
    /// Enumerates the geocoding datasets in PxPoint.
    /// </summary>
    public enum PxPointGeocodingDataset
    {
        /// <summary>
        /// The NAVTEQ street dataset.
        /// </summary>
        NavteqStreet,

        /// <summary>
        /// No dataset.
        /// </summary>
        None,

        /// <summary>
        /// The parcel dataset.
        /// </summary>
        Parcel,

        /// <summary>
        /// The structure dataset.
        /// </summary>
        Structure,

        /// <summary>
        /// The USPS dataset.
        /// </summary>
        Usps
    }
}