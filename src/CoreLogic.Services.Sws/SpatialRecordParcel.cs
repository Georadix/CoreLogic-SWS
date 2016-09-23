namespace CoreLogic.Services.Sws
{
    using Newtonsoft.Json;

    /// <summary>
    /// Represents parcel information returned by SpatialRecord.
    /// </summary>
    public class SpatialRecordParcel
    {
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        [JsonProperty(PropertyName = "ADDR")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the APN.
        /// </summary>
        [JsonProperty(PropertyName = "APN")]
        public string Apn { get; set; }

        /// <summary>
        /// Gets or sets the APN sequence number.
        /// </summary>
        [JsonProperty(PropertyName = "APN_SEQ_NO")]
        public int? ApnSequenceNumber { get; set; }

        /// <summary>
        /// Gets or sets the total appraised value of the parcel's land and improvement values as provided by the
        /// county or local taxing/assessment authority.
        /// </summary>
        [JsonProperty(PropertyName = "APPR_VAL")]
        public int? AppraisedTotalValue { get; set; }

        /// <summary>
        /// Gets or sets the assessed improvement value as provided by the county or local taxing/assessment authority.
        /// </summary>
        [JsonProperty(PropertyName = "ASSD_IMP")]
        public int? AssessedImprovementValue { get; set; }

        /// <summary>
        /// Gets or sets the assessed land value as provided by the county or local taxing/assessment authority.
        /// </summary>
        [JsonProperty(PropertyName = "ASSD_LAN")]
        public int? AssessedLandValue { get; set; }

        /// <summary>
        /// Gets or sets the total assessed value of the parcel's land and improvement values as provided by the county
        /// or local taxing/assessment authority.
        /// </summary>
        [JsonProperty(PropertyName = "ASSD_VAL")]
        public int? AssessedTotalValue { get; set; }

        /// <summary>
        /// Gets or sets the assessed year.
        /// </summary>
        [JsonProperty(PropertyName = "ASSD_YR")]
        public int? AssessedYear { get; set; }

        /// <summary>
        /// Gets or sets the total square footage associated with the basement portion of a building. This would
        /// include both finished and unfinished areas.
        /// </summary>
        [JsonProperty(PropertyName = "BSMT_SQ_FT")]
        public double? BasementSqFt { get; set; }

        /// <summary>
        /// Gets or sets the size of the building in square feet. This is commonly populated as a cumulative total when
        /// a county does not differentiate between living and non-living areas.
        /// </summary>
        [JsonProperty(PropertyName = "BLD_SQ_FT")]
        public int? BuildingSqFt { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        [JsonProperty(PropertyName = "CITY")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the primary method of construction (e.g. steel/glass, concrete block, log).
        /// </summary>
        [JsonProperty(PropertyName = "CONSTR_TYP")]
        public string ConstructionType { get; set; }

        /// <summary>
        /// Gets or sets the county code.
        /// </summary>
        [JsonProperty(PropertyName = "CNTY_CODE")]
        public string CountyCode { get; set; }

        /// <summary>
        /// Gets or sets the type and/or finish of the exterior walls (e.g. vinyl siding, brick veneer, frame/stone).
        /// </summary>
        [JsonProperty(PropertyName = "EXT_WALLS")]
        public string ExteriorWalls { get; set; }

        /// <summary>
        /// Gets or sets the FIPS code.
        /// </summary>
        [JsonProperty(PropertyName = "FIPS_CODE")]
        public string FipsCode { get; set; }

        /// <summary>
        /// Gets or sets the formatted APN.
        /// </summary>
        [JsonProperty(PropertyName = "FRM_APN")]
        public string FormattedApn { get; set; }

        /// <summary>
        /// Gets or sets the geometry.
        /// </summary>
        [JsonProperty(PropertyName = "GEOM")]
        public string Geometry { get; set; }

        /// <summary>
        /// Gets or sets the type or method of heating (e.g. hot water, heat pump, baseboard, radiant).
        /// </summary>
        [JsonProperty(PropertyName = "HEATING")]
        public string Heating { get; set; }

        /// <summary>
        /// Gets or sets the improvement value closest to current market value used for assessment by county or local
        /// taxing authorities.
        /// </summary>
        [JsonProperty(PropertyName = "IMP_VAL")]
        public int? ImprovementValue { get; set; }

        /// <summary>
        /// Gets or sets the total land mass in acres.
        /// </summary>
        [JsonProperty(PropertyName = "LAND_ACRES")]
        public double? LandAcres { get; set; }

        /// <summary>
        /// Gets or sets the total land mass in square feet.
        /// </summary>
        [JsonProperty(PropertyName = "LAND_SQ_FT")]
        public int? LandSqFt { get; set; }

        /// <summary>
        /// Gets or sets the FARES established land use code to aid in search and extract functions.
        /// </summary>
        [JsonProperty(PropertyName = "LAND_USE")]
        public string LandUse { get; set; }

        /// <summary>
        /// Gets or sets the land value closest to current market value used for assessment by county or local taxing
        /// authorities.
        /// </summary>
        [JsonProperty(PropertyName = "LAN_VAL")]
        public int? LandValue { get; set; }

        /// <summary>
        /// Gets or sets the area of a building that is used for general living. This is typically the area of a
        /// building that is heated or air conditioned and does not include garage, porch, or basement square footage.
        /// </summary>
        [JsonProperty(PropertyName = "LIV_SQ_FT")]
        public double? LivingSqFt { get; set; }

        /// <summary>
        /// Gets or sets the market improvement value as provided by the county or local taxing/assessment authority.
        /// </summary>
        [JsonProperty(PropertyName = "MKT_IMP")]
        public int? MarketImprovementValue { get; set; }

        /// <summary>
        /// Gets or sets the market land value as provided by the county or local taxing/assessment authority.
        /// </summary>
        [JsonProperty(PropertyName = "MKT_LAN")]
        public int? MarketLandValue { get; set; }

        /// <summary>
        /// Gets or sets the total market value of the parcel's land and improvement values as provided by the county
        /// or local taxing/assessment authority.
        /// </summary>
        [JsonProperty(PropertyName = "MKT_VAL")]
        public int? MarketTotalValue { get; set; }

        /// <summary>
        /// Gets or sets the total number of buildings on the parcel.
        /// </summary>
        [JsonProperty(PropertyName = "BLD_UNITS")]
        public int? NumberOfBuildings { get; set; }

        /// <summary>
        /// Gets or sets the number of fireplace openings located within the building.
        /// </summary>
        [JsonProperty(PropertyName = "FRPLCE_NBR")]
        public int? NumberOfFireplaces { get; set; }

        /// <summary>
        /// Gets or sets the number of stories associated with the building.
        /// </summary>
        [JsonProperty(PropertyName = "STORY_NBR")]
        public double? NumberOfStories { get; set; }

        /// <summary>
        /// Gets or sets the original APN.
        /// </summary>
        [JsonProperty(PropertyName = "ORIG_APN")]
        public string OriginalApn { get; set; }

        /// <summary>
        /// Gets or sets whether the name of the property owner has been recognized as a corporation or business.
        /// </summary>
        [JsonProperty(PropertyName = "OWN_CP_IND")]
        public string OwnerCorporateIndicator { get; set; }

        /// <summary>
        /// Gets or sets the first name of the property owner.
        /// </summary>
        [JsonProperty(PropertyName = "OWN1_FRST")]
        public string OwnerFirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the property owner.
        /// </summary>
        [JsonProperty(PropertyName = "OWN1_LAST")]
        public string OwnerLastName { get; set; }

        /// <summary>
        /// Gets or sets the FARES general code used to easily recognize specific property types (e.g. Residential,
        /// Condominium, Commercial).
        /// </summary>
        [JsonProperty(PropertyName = "PROP_IND")]
        public string PropertyIndicator { get; set; }

        /// <summary>
        /// Gets or sets the type of construction quality of building (e.g. excellent, economical).
        /// </summary>
        [JsonProperty(PropertyName = "QUALITY")]
        public string Quality { get; set; }

        /// <summary>
        /// Gets or sets the type of roof cover (e.g. clay tile, aluminum, shake).
        /// </summary>
        [JsonProperty(PropertyName = "ROOF_COVER")]
        public string RoofCover { get; set; }

        /// <summary>
        /// Gets or sets the type of roof shape (e.g. gambrel, gable, flat, mansard).
        /// </summary>
        [JsonProperty(PropertyName = "ROOF_TYP")]
        public string RoofType { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        [JsonProperty(PropertyName = "STATE")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the state code.
        /// </summary>
        [JsonProperty(PropertyName = "STATE_CODE")]
        public string StateCode { get; set; }

        /// <summary>
        /// Gets or sets the total (i.e. land + improvement) value closest to current market value used for assessment
        /// by county or local taxing authorities.
        /// </summary>
        [JsonProperty(PropertyName = "TOT_VAL")]
        public int? TotalValue { get; set; }

        /// <summary>
        /// Gets or sets the unformatted APN.
        /// </summary>
        [JsonProperty(PropertyName = "UNFRM_APN")]
        public string UnformattedAPN { get; set; }

        /// <summary>
        /// Gets or sets the building square footage that can most accurately be used for assessments
        /// (e.g. living, adjusted gross).
        /// </summary>
        [JsonProperty(PropertyName = "UBLD_SQ_FT")]
        public int? UniversalBuildingSqFt { get; set; }

        /// <summary>
        /// Gets or sets the construction year of the original building.
        /// </summary>
        [JsonProperty(PropertyName = "YR_BLT")]
        public int? YearBuilt { get; set; }

        /// <summary>
        /// Gets or sets the ZIP code.
        /// </summary>
        [JsonProperty(PropertyName = "ZIP")]
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the zoning.
        /// </summary>
        [JsonProperty(PropertyName = "ZONING")]
        public string Zoning { get; set; }
    }
}