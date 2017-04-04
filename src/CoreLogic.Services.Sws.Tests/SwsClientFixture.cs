namespace CoreLogic.Services.Sws
{
    using Moq;
    using Xunit;

    public class SwsClientFixture
    {
        private readonly Mock<ISwsConfig> config = new Mock<ISwsConfig>(MockBehavior.Strict);

        public SwsClientFixture()
        {
            this.config.Setup(c => c.Username).Returns("username");
            this.config.Setup(c => c.Password).Returns("password");
            this.config.Setup(c => c.NonSolicitationAreaWkt).Returns<string>(null);
            this.config.Setup(c => c.EndpointUrl).Returns("http://sws.corelogic.com/api/v3.0.0/");
            this.config.Setup(c => c.Timeout).Returns(10);
        }

        [Fact(Skip = "External web service call, run manually.")]
        public void GeocodeReturnsExpectedResult()
        {
            var sut = new SwsClient(this.config.Object);

            var response = sut.Geocode("115 OLD FIELD LN, ST AUGUSTINE, FL 32092");

            Assert.NotNull(response);
        }

        [Fact(Skip = "External web service call, run manually.")]
        public void GetAuthorizedFeaturesReturnsIt()
        {
            var sut = new SwsClient(this.config.Object);

            var response = sut.GetAuthorizedFeatures("authKey");

            Assert.NotNull(response);
        }

        [Theory(Skip = "External web service call, run manually.")]
        [InlineData("Idaho", "POLYGON((-112.04184651374817 43.49312138312793,-112.04257071018219 43.49218348707646,-112.03920185565948 43.49085639765385,-112.03851521015167 43.491767072127324,-112.04184651374817 43.49312138312793))", 41, 0)]
        [InlineData("Kansas", "POLYGON((-94.6085661649704 39.105142361657066,-94.60488617420197 39.10517150078678,-94.60556209087372 39.10362711031401,-94.60846424102783 39.10392267013844,-94.6085661649704 39.105142361657066))", 33, 20)]
        [InlineData("Montana", "POLYGON((-108.54085296392441 45.77408241527412,-108.53938847780228 45.77408054446194,-108.53931605815887 45.7735791645344,-108.54086101055145 45.77360348530656,-108.54085296392441 45.77408241527412))", 8, 0)]
        [InlineData("Texas", "POLYGON((-96.82873249053955 32.8216640890017,-96.82787418365479 32.820996894866276,-96.82874858379364 32.8204423986301,-96.82948887348175 32.82102845145856,-96.82873249053955 32.8216640890017))", 13, 13)]
        public void GetSpatialRecordParcelCountLimitedBySolicitationShouldFilterResults(
            string state, string polygonWkt, int unfilteredCount, int filteredCount)
        {
            var sut = new SwsClient(this.config.Object);
            var count = sut.GetSpatialRecordParcelCount(polygonWkt);

            Assert.Equal(unfilteredCount, count);

            var limitedCount = sut.GetSpatialRecordParcelCount(
                polygonWkt: polygonWkt, excludeNonSolicitationStates: true);

            Assert.Equal(filteredCount, limitedCount);
        }

        [Fact(Skip = "External web service call, run manually.")]
        public void GetSpatialRecordParcelCountWithPolygonReturnsCount()
        {
            var sut = new SwsClient(this.config.Object);

            var count = sut.GetSpatialRecordParcelCount(
                "authKey",
                "Polygon((-77.042999 38.89601,-77.039459 38.894239,-77.033536 38.896911,-77.041197 38.899467,-77.042999 38.89601))");

            Assert.Equal(30, count);
        }

        [Theory(Skip = "External web service call, run manually.")]
        [InlineData("Idaho", "POLYGON((-112.04184651374817 43.49312138312793,-112.04257071018219 43.49218348707646,-112.03920185565948 43.49085639765385,-112.03851521015167 43.491767072127324,-112.04184651374817 43.49312138312793))", 41, 0)]
        [InlineData("Kansas", "POLYGON((-94.6085661649704 39.105142361657066,-94.60488617420197 39.10517150078678,-94.60556209087372 39.10362711031401,-94.60846424102783 39.10392267013844,-94.6085661649704 39.105142361657066))", 33, 20)]
        [InlineData("Montana", "POLYGON((-108.54085296392441 45.77408241527412,-108.53938847780228 45.77408054446194,-108.53931605815887 45.7735791645344,-108.54086101055145 45.77360348530656,-108.54085296392441 45.77408241527412))", 8, 0)]
        [InlineData("Texas", "POLYGON((-96.82873249053955 32.8216640890017,-96.82787418365479 32.820996894866276,-96.82874858379364 32.8204423986301,-96.82948887348175 32.82102845145856,-96.82873249053955 32.8216640890017))", 13, 13)]
        public void GetSpatialRecordParcelsLimitedBySolicitationShouldFilterResults(
            string state, string polygonWkt, int unfilteredCount, int filteredCount)
        {
            var sut = new SwsClient(this.config.Object);
            var parcels = sut.GetSpatialRecordParcels(polygonWkt);

            Assert.Equal(unfilteredCount, parcels.Length);

            var limitedParcels = sut.GetSpatialRecordParcels(
                polygonWkt: polygonWkt, excludeNonSolicitationStates: true);

            Assert.Equal(filteredCount, limitedParcels.Length);
        }

        [Fact(Skip = "External web service call, run manually.")]
        public void GetSpatialRecordParcelsWithLatLongReturnsParcels()
        {
            var sut = new SwsClient(this.config.Object);

            var parcels = sut.GetSpatialRecordParcels(30.406001, -97.716578);

            Assert.Equal(1, parcels.Length);
        }

        [Fact(Skip = "External web service call, run manually.")]
        public void GetSpatialRecordParcelsWithPolygonReturnsParcels()
        {
            var sut = new SwsClient(this.config.Object);

            var parcels = sut.GetSpatialRecordParcels(
                "Polygon((-77.042999 38.89601,-77.039459 38.894239,-77.033536 38.896911,-77.041197 38.899467,-77.042999 38.89601))");

            Assert.Equal(30, parcels.Length);
        }
    }
}