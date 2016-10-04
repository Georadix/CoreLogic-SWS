namespace CoreLogic.Services.Sws
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Enumerates the geocoding datasets in PxPoint.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PxPointGeocodingDataset
    {
        /// <summary>
        /// The NAVTEQ street dataset.
        /// </summary>
        [EnumMember(Value = "NAVTEQ_STREET")]
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