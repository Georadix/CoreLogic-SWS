namespace CoreLogic.Services.Sws
{
    /// <summary>
    /// Represents geocode details returned by PxPoint.
    /// </summary>
    public class PxPointGeocodeDetails
    {
        /// <summary>
        /// Gets or sets the APN2 information. This type of tax Assessor's Parcel Number (APN) is one that a revised
        /// property parcel (a parcel that has been subdivided from or added to another parcel) uses to reference the
        /// original parcel. The exact format differs by tax authority.
        /// </summary>
        public PxPointStringArray Apn2 { get; set; }

        /// <summary>
        /// Gets or sets the complete crossing street name including any directionals (N, S, E, W, and so on),
        /// prefixes, or suffixes. Cross street information is available for intersection matches only.
        /// </summary>
        public string CrossStreet { get; set; }

        /// <summary>
        /// Gets or sets the base crossing street name. This is the crossing street name without any directionals,
        /// prefixes, or suffixes. Cross street information is available for intersection matches only.
        /// </summary>
        public string CrossStreetBase { get; set; }

        /// <summary>
        /// Gets or sets the crossing street prefix information. Cross street information is available for intersection
        /// matches only.
        /// </summary>
        public string CrossStreetPrefix { get; set; }

        /// <summary>
        /// Gets or sets the crossing street prefix directional (N, S, E, W, and so on) information. Cross street
        /// information is available for intersection matches only.
        /// </summary>
        public string CrossStreetPrefixDirectional { get; set; }

        /// <summary>
        /// Gets or sets the crossing street suffix information. Cross street information is available for intersection
        /// matches only.
        /// </summary>
        public string CrossStreetSuffix { get; set; }

        /// <summary>
        /// Gets or sets the crossing street suffix directional (N, S, E, W, and so on) information. Cross street
        /// information is available for intersection matches only.
        /// </summary>
        public string CrossStreetSuffixDirectional { get; set; }

        /// <summary>
        /// Gets or sets the house number.
        /// </summary>
        public string HouseNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the location is an intersection.
        /// </summary>
        public bool IsIntersection { get; set; }

        /// <summary>
        /// Gets or sets the human-readable match code description.
        /// </summary>
        public string MatchCodeDescription { get; set; }

        /// <summary>
        /// Gets or sets the street Segment ID.
        /// </summary>
        public string SegmentId { get; set; }

        /// <summary>
        /// Gets or sets the complete street name including directionals (N, S, E, W, and so on), prefixes, or
        /// suffixes.
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// Gets or sets the base street name. This is the street name without any directionals, prefixes, or suffixes.
        /// </summary>
        public string StreetNameBase { get; set; }

        /// <summary>
        /// Gets or sets the street prefix information.
        /// </summary>
        public string StreetNamePrefix { get; set; }

        /// <summary>
        /// Gets or sets the street prefix directional (N, S, E, W, and so on) information.
        /// </summary>
        public string StreetNamePrefixDirectional { get; set; }

        /// <summary>
        /// Gets or sets the street suffix information.
        /// </summary>
        public string StreetNameSuffix { get; set; }

        /// <summary>
        /// Gets or sets the street suffix directional (N, S, E, W, and so on) information.
        /// </summary>
        public string StreetNameSuffixDirectional { get; set; }

        /// <summary>
        /// Gets or sets the unit number.
        /// </summary>
        public string UnitNumber { get; set; }

        /// <summary>
        /// Gets or sets the unit designation only, such as APT or STE.
        /// </summary>
        public string UnitType { get; set; }
    }
}