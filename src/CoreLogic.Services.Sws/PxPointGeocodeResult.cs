namespace CoreLogic.Services.Sws
{
    /// <summary>
    /// Represents a PxPoint geocode result.
    /// </summary>
    public class PxPointGeocodeResult
    {
        /// <summary>
        /// Gets or sets the address line matched by the PxPoint geocoder.
        /// </summary>
        public string AddressLine { get; set; }

        /// <summary>
        /// Gets or sets the name of the city.
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// Gets or sets the geocode details.
        /// </summary>
        public PxPointGeocodeDetails Details { get; set; }

        /// <summary>
        /// Gets or sets the dataset used for the match.
        /// </summary>
        public PxPointGeocodingDataset GeocodingDataset { get; set; }

        /// <summary>
        /// Gets or sets the address input for geocoding.
        /// </summary>
        public string InputAddress { get; set; }

        /// <summary>
        /// Gets or sets the geographic coordinate that specifies the north-south position of a point on the Earth's
        /// surface.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the geographic coordinate that specifies the east-west position of a point on the Earth's
        /// surface.
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Gets or sets the match code for the found location.
        /// </summary>
        public string MatchCode { get; set; }

        /// <summary>
        /// Gets or sets how confident PxPoint is that the input address matches the found address.
        /// </summary>
        public PxPointMatchConfidence MatchConfidence { get; set; }

        /// <summary>
        /// Gets or sets the address matched by the PxPoint geocoder.
        /// </summary>
        public string MatchedAddress { get; set; }

        /// <summary>
        /// Gets or sets the Assessor's Parcel Number (APN) for the matched location, if the match was from the parcel
        /// dataset. If the match was from some other dataset, this will be an empty string.
        /// </summary>
        public PxPointStringArray ParcelId { get; set; }

        /// <summary>
        /// Gets or sets the state abbreviation.
        /// </summary>
        public string StateCode { get; set; }

        /// <summary>
        /// Gets or sets the ID of the structure(s) identified for the location requested.
        /// </summary>
        public PxPointStringArray StructureId { get; set; }

        /// <summary>
        /// Gets or sets the USPSGeoLevel code number, which is an indicator of match quality. The possible values are:
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// "0" - No centroid available for this area.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// "1" - ZIP+4 centroid for the midpoint of a ZIP+4 area. Often accurate to a city block, or nearby block.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// "4" - ZIP Code centroid for the midpoint of a 5-digit ZIP Code. Accuracy depends on the size of the ZIP Code.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// "" - An empty value is returned if the match was not based on the USPS dataset.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        public string UspsGeoLevel { get; set; }

        /// <summary>
        /// Gets or sets the one-character USPS record type code. Use this code, along with the USPSGeoLevel code, to
        /// help judge the precision of a USPS match location. The centroids of USPS matches with F, H, and S record
        /// types, plus a USPSGeoLevel value of 1, are usually precise to the length of a city block. However, the
        /// centroids of USPSGeoLevel 1 matches with P, G, and R record types are as imprecise as those of all
        /// USPSGeoLevel 4 matches. These matches are usually quite a distance (many blocks, perhaps even miles) away
        /// from the input address. The possible values are:
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// "F" is Firm (a Business)
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// "G" is General Delivery
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// "H" is High-Rise
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// "P" is PO Box
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// "R" is Rural Route/Highway Contract
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// "S" is Street
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        public string UspsRecType { get; set; }

        /// <summary>
        /// Gets or sets the 5-digit ZIP Code.
        /// </summary>
        public string ZipCode { get; set; }
    }
}