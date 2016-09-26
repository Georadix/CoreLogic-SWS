namespace CoreLogic.Services.Sws
{
    public class SwsSamples
    {
        public static SpatialRecordParcel SpatialRecordParcel
        {
            get
            {
                return new SpatialRecordParcel
                {
                    Address = "Address",
                    Apn = "Apn",
                    ApnSequenceNumber = 1,
                    AssessedImprovementValue = 1,
                    AssessedLandValue = 1,
                    AssessedTotalValue = 1,
                    AssessedYear = 2000,
                    BasementSqFt = 1,
                    BuildingSqFt = 1,
                    City = "City",
                    ConstructionType = "Construction Type",
                    CountyCode = "County",
                    ExteriorWalls = "ExteriorWalls",
                    FipsCode = "FipsCode",
                    FormattedApn = "FomattedApn",
                    Geometry = "Geometry",
                    Heating = "Heating",
                    ImprovementValue = 1,
                    LandAcres = 1.0,
                    LandSqFt = 1,
                    LandUse = "LandUse",
                    MarketLandValue = 1,
                    MarketTotalValue = 1,
                    NumberOfBuildings = 1,
                    NumberOfFireplaces = 1,
                    NumberOfStories = 1,
                    OriginalApn = "OriginalApn",
                    OwnerCorporateIndicator = "OwnerCorporateIndicator",
                    OwnerFirstName = "OwnerFirstName",
                    OwnerLastName = "OwnerLastName",
                    PropertyIndicator = "PropertyIndicator",
                    Quality = "Quality",
                    RoofCover = "RoofCover",
                    RoofType = "RoofType",
                    State = "State",
                    StateCode = "StateCode",
                    TotalValue = 1,
                    UnformattedAPN = "UnformattedAPN",
                    UniversalBuildingSqFt = 1,
                    YearBuilt = 2000,
                    ZipCode = "ZipCode",
                    Zoning = "Zoning"
                };
            }
        }
    }
}