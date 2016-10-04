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

        [Fact(Skip = "External web service call, run manually.")]
        public void GetSpatialRecordParcelCountWithPolygonReturnsCount()
        {
            var sut = new SwsClient(this.config.Object);

            var count = sut.GetSpatialRecordParcelCount(
                "authKey",
                "Polygon((-77.042999 38.89601,-77.039459 38.894239,-77.033536 38.896911,-77.041197 38.899467,-77.042999 38.89601))");

            Assert.Equal(30, count);
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