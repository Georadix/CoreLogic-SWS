namespace CoreLogic.Services.Sws
{
    using Georadix.Core;
    using Georadix.WebApi.Testing;
    using Moq;
    using Newtonsoft.Json;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using Xunit;

    public class SwsClientFixture : IDisposable
    {
        private const string Address = "11902 BURNET ROAD, AUSTIN, TX  78758";
        private const string AuthKey = "TestingAuthKey";
        private readonly Mock<ISwsConfig> config = new Mock<ISwsConfig>(MockBehavior.Strict);
        private readonly FakeResponseHandler fakeResponseHandler;
        private SwsClient sut;
        private bool disposed = false;

        public SwsClientFixture()
        {
            ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol | SecurityProtocolType.Tls12;

            this.config.Setup(c => c.Username).Returns("username");
            this.config.Setup(c => c.Password).Returns("password");
            this.config.Setup(c => c.NonSolicitationAreaWkt).Returns<string>(null);
            this.config.Setup(c => c.EndpointUrl).Returns("https://sws.beta.corelogic.com/api/v3.0.0/");
            this.config.Setup(c => c.Timeout).Returns(10);

            this.fakeResponseHandler = new FakeResponseHandler();

            this.sut = new SwsClient(this.config.Object, this.fakeResponseHandler);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="SwsClientFixture"/> class.
        /// </summary>
        ~SwsClientFixture()
        {
            this.Dispose(false);
        }

        [Fact]
        public void DeserializeAuthorizedFeaturesSuccessReturnsMappedInstance()
        {
            var deserialized = JsonConvert.DeserializeObject<AuthorizedFeaturesResponse>(
                SwsSamples.AuthorizedFeaturesSuccess);

            Assert.Collection(
                deserialized.Features,
                item => Assert.True(item.Description == "All Licensed Products" && item.Name == "AllLicensed"));

            Assert.Collection(
                deserialized.Operations,
                item => Assert.True(
                    item.Description == "SpatialRecordUTPremium" && item.Name == "SpatialRecordUTPremium"),
                item => Assert.True(
                    item.Description == "Get Parcels" && item.Name == "GetParcels"),
                item => Assert.True(
                    item.Description == "SpatialRecordOGPremium" && item.Name == "SpatialRecordOGPremium"));
        }

        [Fact]
        public void DeserializeAuthReturnsMappedInstance()
        {
            var deserialized = JsonConvert.DeserializeObject<AuthResponse>(SwsSamples.AuthenticateSuccess);

            Assert.Equal("NewAuthKey", deserialized.AuthKey);
        }

        [Fact]
        public void DeserializePageInfoReturnsMappedInstance()
        {
            var deserialized = JsonConvert.DeserializeObject<PageInfo>(SwsSamples.PageInfo);

            Assert.Equal(1, deserialized.ActualPageSize);
            Assert.Equal(1, deserialized.Length);
            Assert.Equal(50, deserialized.MaxPageSize);
            Assert.Equal(1, deserialized.Page);
            Assert.Equal(50, deserialized.PageSize);
        }

        [Fact]
        public void DeserializePxPointGeocodeResultReturnsMappedInstance()
        {
            var deserialized = JsonConvert.DeserializeObject<PxPointGeocodeResponse>(SwsSamples.GeocodeSuccess)
                .Location;

            Assert.Equal("11902 BURNET RD", deserialized.AddressLine);
            Assert.Equal("AUSTIN", deserialized.CityName);
            Assert.Collection(
                deserialized.Details.Apn2.Values,
                item => Assert.Equal("0258080104", item),
                item => Assert.Equal("0258080103", item));
            Assert.Equal("11902", deserialized.Details.HouseNumber);
            Assert.False(deserialized.Details.IsIntersection);
            Assert.Equal("Matched unique number", deserialized.Details.MatchCodeDescription);
            Assert.Equal("BURNET RD", deserialized.Details.StreetName);
            Assert.Equal("BURNET", deserialized.Details.StreetNameBase);
            Assert.Equal("RD", deserialized.Details.StreetNameSuffix);
            Assert.Equal(PxPointGeocodingDataset.Structure, deserialized.GeocodingDataset);
            Assert.Equal("11902 BURNET ROAD, AUSTIN, TX  78758", deserialized.InputAddress);
            Assert.Equal(30.406014, deserialized.Latitude);
            Assert.Equal(-97.716997, deserialized.Longitude);
            Assert.Equal("A0000", deserialized.MatchCode);
            Assert.Equal(PxPointMatchConfidence.High, deserialized.MatchConfidence);
            Assert.Equal("11902 BURNET RD,AUSTIN TX  78758", deserialized.MatchedAddress);
            Assert.Collection(
                deserialized.ParcelId.Values,
                item => Assert.Equal("548320", item),
                item => Assert.Equal("548319", item));
            Assert.Equal("TX", deserialized.StateCode);
            Assert.Collection(
                deserialized.StructureId.Values,
                item => Assert.Equal("13808356", item),
                item => Assert.Equal("13808504", item),
                item => Assert.Equal("13808745", item),
                item => Assert.Equal("13808592", item));
            Assert.Equal("78758", deserialized.ZipCode);
        }

        [Fact]
        public void DeserializeSpatialRecordParcelReturnsMappedInstance()
        {
            var deserialized = JsonConvert.DeserializeObject<SpatialRecordParcel>(SwsSamples.SpatialRecordParcel);

            Assert.Equal("11902 BURNET RD", deserialized.Address);
            Assert.Equal("548319", deserialized.Apn);
            Assert.Equal(1, deserialized.ApnSequenceNumber);
            Assert.Equal(16291424, deserialized.AppraisedTotalValue);
            Assert.Equal(13145524, deserialized.AssessedImprovementValue);
            Assert.Equal(3145900, deserialized.AssessedLandValue);
            Assert.Equal(16291424, deserialized.AssessedTotalValue);
            Assert.Equal(2016, deserialized.AssessedYear);
            Assert.Equal(77450, deserialized.BuildingSqFt);
            Assert.Equal("AUSTIN", deserialized.City);
            Assert.Equal("001", deserialized.ConstructionType);
            Assert.Equal("453", deserialized.CountyCode);
            Assert.Equal("48453", deserialized.FipsCode);
            Assert.Equal("548319", deserialized.FormattedApn);
            Assert.Equal(
                "POLYGON ((-97.7 30.4, -97.7 30.5, -97.6 30.5, -97.6 30.4, -97.7 30.4))",
                deserialized.Geometry);
            Assert.Equal(13145524, deserialized.ImprovementValue);
            Assert.Equal(3.611, deserialized.LandAcres);
            Assert.Equal(157295, deserialized.LandSqFt);
            Assert.Equal("244", deserialized.LandUse);
            Assert.Equal(3145900, deserialized.LandValue);
            Assert.Equal(77450, deserialized.LivingSqFt);
            Assert.Equal(13145524, deserialized.MarketImprovementValue);
            Assert.Equal(3145900, deserialized.MarketLandValue);
            Assert.Equal(16291424, deserialized.MarketTotalValue);
            Assert.Equal(1, deserialized.NumberOfBuildings);
            Assert.Equal(4, deserialized.NumberOfStories);
            Assert.Equal("548319", deserialized.OriginalApn);
            Assert.Equal("Y", deserialized.OwnerCorporateIndicator);
            Assert.Equal("CH REALTY VI/O AUSTIN STONECREEK", deserialized.OwnerLastName);
            Assert.Equal("27", deserialized.PropertyIndicator);
            Assert.Equal("003", deserialized.RoofCover);
            Assert.Equal("F00", deserialized.RoofType);
            Assert.Equal("TX", deserialized.State);
            Assert.Equal("48", deserialized.StateCode);
            Assert.Equal(16291424, deserialized.TotalValue);
            Assert.Equal("548319", deserialized.UnformattedAPN);
            Assert.Equal(77450, deserialized.UniversalBuildingSqFt);
            Assert.Equal(1984, deserialized.YearBuilt);
            Assert.Equal("78758", deserialized.ZipCode);
        }

        [Fact]
        public void DeserializeSpatialRecordSuccessReturnsMappedInstance()
        {
            var deserialized = JsonConvert.DeserializeObject<SpatialRecordResponse>(SwsSamples.SpatialRecordSuccess);

            Assert.NotNull(deserialized.PageInfo);
            Assert.NotEmpty(deserialized.Parcels);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        [Fact]
        public void GeocodeReturnsResult()
        {
            this.fakeResponseHandler.AddFakeGetResponse(
                new Uri(string.Format(
                    "{0}geocode?address={1}&full=false&authKey={2}",
                    this.config.Object.EndpointUrl,
                    Address,
                    AuthKey)),
                () => new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(SwsSamples.GeocodeSuccess, Encoding.Unicode, "application/json")
                });

            var expectedResponse = JsonConvert.DeserializeObject<PxPointGeocodeResponse>(
                SwsSamples.GeocodeSuccess).Location;

            var actualResponse = this.sut.Geocode(AuthKey, Address);

            Assert.True(new GenericEqualityComparer<PxPointGeocodeResult>().Equals(expectedResponse, actualResponse));
        }

        [Fact]
        public void GeocodeWithNoAuthKeyCausesAuthentication()
        {
            this.AddFakeAuthenticateSuccessResponse();

            this.fakeResponseHandler.AddFakeGetResponse(
                new Uri(string.Format(
                    "{0}geocode?address={1}&full=false&authKey=NewAuthKey",
                    this.config.Object.EndpointUrl,
                    Address)),
                () => new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(SwsSamples.GeocodeSuccess, Encoding.Unicode, "application/json")
                });

            this.sut.Geocode(Address);
        }

        [Fact]
        public void GetAuthorizedFeaturesReturnsFeaturesAndOperations()
        {
            this.fakeResponseHandler.AddFakeGetResponse(
                new Uri(this.config.Object.EndpointUrl + "features?authKey=" + AuthKey),
                () => new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(
                        SwsSamples.AuthorizedFeaturesSuccess,
                        Encoding.Unicode,
                        "application/json")
                });

            var expectedResponse = JsonConvert.DeserializeObject<AuthorizedFeaturesResponse>(
                SwsSamples.AuthorizedFeaturesSuccess);

            var actualResponse = this.sut.GetAuthorizedFeatures(AuthKey);

            Assert.True(
                new GenericEqualityComparer<AuthorizedFeaturesResponse>().Equals(expectedResponse, actualResponse));
        }

        [Fact]
        public void GetAuthorizedFeaturesWithNoAuthKeyCausesAuthentication()
        {
            this.AddFakeAuthenticateSuccessResponse();

            this.fakeResponseHandler.AddFakeGetResponse(
                new Uri(this.config.Object.EndpointUrl + "features?authKey=NewAuthKey"),
                () => new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(
                        SwsSamples.AuthorizedFeaturesSuccess,
                        Encoding.Unicode,
                        "application/json")
                });

            this.sut.GetAuthorizedFeatures();
        }

        [Theory(Skip = "External web service call, run manually.")]
        [InlineData("Idaho", "POLYGON((-112.04184651374817 43.49312138312793,-112.04257071018219 43.49218348707646,-112.03920185565948 43.49085639765385,-112.03851521015167 43.491767072127324,-112.04184651374817 43.49312138312793))", 41, 0)]
        [InlineData("Kansas", "POLYGON((-94.6085661649704 39.105142361657066,-94.60488617420197 39.10517150078678,-94.60556209087372 39.10362711031401,-94.60846424102783 39.10392267013844,-94.6085661649704 39.105142361657066))", 24, 20)]
        [InlineData("Montana", "POLYGON((-108.54085296392441 45.77408241527412,-108.53938847780228 45.77408054446194,-108.53931605815887 45.7735791645344,-108.54086101055145 45.77360348530656,-108.54085296392441 45.77408241527412))", 8, 0)]
        [InlineData("Texas", "POLYGON((-96.82873249053955 32.8216640890017,-96.82787418365479 32.820996894866276,-96.82874858379364 32.8204423986301,-96.82948887348175 32.82102845145856,-96.82873249053955 32.8216640890017))", 13, 13)]
        public void GetSpatialRecordParcelCountExcludingNonSolicitationStatesFilterResults(
            string state, string polygonWkt, int unfilteredCount, int filteredCount)
        {
            this.sut = new SwsClient(this.config.Object);

            var count = this.sut.GetSpatialRecordParcelCount(polygonWkt);

            Assert.Equal(unfilteredCount, count);

            var limitedCount = this.sut.GetSpatialRecordParcelCount(polygonWkt, excludeNonSolicitationStates: true);

            Assert.Equal(filteredCount, limitedCount);
        }

        [Fact]
        public void GetSpatialRecordParcelCountExcludingNonSolicitationStatesReturnsFilteredCount()
        {
            var polygonWkt = "POLYGON((-112.04184651374817 43.49312138312793,-112.04257071018219 43.49218348707646,-112.03920185565948 43.49085639765385,-112.03851521015167 43.491767072127324,-112.04184651374817 43.49312138312793))";
            var requestCount = 0;

            this.fakeResponseHandler.AddFakePostResponse(
                new Uri(string.Format(
                    "{0}parcels",
                    this.config.Object.EndpointUrl)),
                (requestContent) =>
                {
                    requestCount++;
                    Assert.InRange(requestCount, 1, 2);

                    var actualRequest = JsonConvert.DeserializeObject<SpatialRecordPolygonRequest>(requestContent);
                    var expectedRequest = new SpatialRecordPolygonRequest(AuthKey, polygonWkt, requestCount);

                    Assert.True(
                        new GenericEqualityComparer<SpatialRecordPolygonRequest>().Equals(
                            expectedRequest,
                            actualRequest));

                    return new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(
                            (requestCount == 1) ?
                                SwsSamples.SpatialRecordLargePage1 : SwsSamples.SpatialRecordLargePage2,
                            Encoding.Unicode,
                            "application/json")
                    };
                });

            var count = this.sut.GetSpatialRecordParcelCount(AuthKey, polygonWkt, excludeNonSolicitationStates: true);

            Assert.Equal(30, count);
        }

        [Fact]
        public void GetSpatialRecordParcelCountReturnsCount()
        {
            var polygonWkt = "Polygon((-77.1 38.9,-77.1 39,-77 39,-77 38.9,-77.1 38.9))";

            this.fakeResponseHandler.AddFakePostResponse(
                new Uri(string.Format(
                    "{0}parcels",
                    this.config.Object.EndpointUrl)),
                (requestContent) =>
                {
                    var expectedRequest = new SpatialRecordPolygonRequest(AuthKey, polygonWkt, 1, 1);

                    var actualRequest = JsonConvert.DeserializeObject<SpatialRecordPolygonRequest>(requestContent);

                    Assert.True(
                        new GenericEqualityComparer<SpatialRecordPolygonRequest>().Equals(
                            expectedRequest,
                            actualRequest));

                    return new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(
                            SwsSamples.SpatialRecordSuccess, Encoding.Unicode, "application/json")
                    };
                });

            var count = this.sut.GetSpatialRecordParcelCount(AuthKey, polygonWkt);

            Assert.Equal(1, count);
        }

        [Fact]
        public void GetSpatialRecordParcelCountWithNoAuthKeyCausesAuthentication()
        {
            this.AddFakeAuthenticateSuccessResponse();

            var polygonWkt = "Polygon((-77.1 38.9,-77.1 39,-77 39,-77 38.9,-77.1 38.9))";

            this.fakeResponseHandler.AddFakePostResponse(
                new Uri(string.Format(
                    "{0}parcels",
                    this.config.Object.EndpointUrl)),
                (requestContent) =>
                {
                    var expectedRequest = new SpatialRecordPolygonRequest("NewAuthKey", polygonWkt, 1, 1);

                    var actualRequest = JsonConvert.DeserializeObject<SpatialRecordPolygonRequest>(requestContent);

                    Assert.True(
                        new GenericEqualityComparer<SpatialRecordPolygonRequest>().Equals(
                            expectedRequest,
                            actualRequest));

                    return new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(
                            SwsSamples.SpatialRecordSuccess, Encoding.Unicode, "application/json")
                    };
                });

            this.sut.GetSpatialRecordParcelCount(polygonWkt);
        }

        [Fact]
        public void GetSpatialRecordParcelsByLatLongReturnsParcels()
        {
            var lat = 30.406001;
            var lon = -97.716578;

            this.fakeResponseHandler.AddFakeGetResponse(
                new Uri(string.Format(
                    "{0}parcels?pageNumber=1&pageSize=50&bundle=SpatialRecordOGPremium&authKey={1}&lat={2}&lon={3}",
                    this.config.Object.EndpointUrl,
                    AuthKey,
                    lat,
                    lon)),
                () => new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(SwsSamples.SpatialRecordSuccess, Encoding.Unicode, "application/json")
                });

            var expectedResponse = JsonConvert.DeserializeObject<SpatialRecordResponse>(
                SwsSamples.SpatialRecordSuccess).Parcels;

            var actualResponse = this.sut.GetSpatialRecordParcels(AuthKey, lat, lon);

            Assert.True(new GenericEqualityComparer<SpatialRecordParcel[]>().Equals(expectedResponse, actualResponse));
        }

        [Fact]
        public void GetSpatialRecordParcelsByLatLongWithNoAuthKeyCausesAuthentication()
        {
            this.AddFakeAuthenticateSuccessResponse();

            var lat = 30.45;
            var lon = -97.65;

            this.fakeResponseHandler.AddFakeGetResponse(
                new Uri(string.Format(
                    "{0}parcels?pageNumber=1&pageSize=50&bundle=SpatialRecordOGPremium&authKey={1}&lat={2}&lon={3}",
                    this.config.Object.EndpointUrl,
                    "NewAuthKey",
                    lat,
                    lon)),
                () => new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(SwsSamples.SpatialRecordSuccess, Encoding.Unicode, "application/json")
                });

            this.sut.GetSpatialRecordParcels(lat, lon);
        }

        [Fact]
        public void GetSpatialRecordParcelsByPolygonReturnsParcels()
        {
            var polygonWkt = "Polygon((-77.1 38.9,-77.1 39,-77 39,-77 38.9,-77.1 38.9))";

            this.fakeResponseHandler.AddFakePostResponse(
                new Uri(this.config.Object.EndpointUrl + "parcels"),
                (requestContent) =>
                {
                    var expectedRequest = new SpatialRecordPolygonRequest(AuthKey, polygonWkt);

                    var actualRequest = JsonConvert.DeserializeObject<SpatialRecordPolygonRequest>(requestContent);

                    Assert.True(
                        new GenericEqualityComparer<SpatialRecordPolygonRequest>().Equals(
                            expectedRequest,
                            actualRequest));

                    return new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(
                            SwsSamples.SpatialRecordSuccess, Encoding.Unicode, "application/json")
                    };
                });

            var expectedResponse = JsonConvert.DeserializeObject<SpatialRecordResponse>(
                SwsSamples.SpatialRecordSuccess).Parcels;

            var actualResponse = this.sut.GetSpatialRecordParcels(AuthKey, polygonWkt);

            Assert.True(new GenericEqualityComparer<SpatialRecordParcel[]>().Equals(expectedResponse, actualResponse));
        }

        [Fact]
        public void GetSpatialRecordParcelsByPolygonWithNoAuthKeyCausesAuthentication()
        {
            this.AddFakeAuthenticateSuccessResponse();

            var polygonWkt = "Polygon((-77.1 38.9,-77.1 39,-77 39,-77 38.9,-77.1 38.9))";

            this.fakeResponseHandler.AddFakePostResponse(
                new Uri(this.config.Object.EndpointUrl + "parcels"),
                (requestContent) =>
                {
                    var expectedRequest = new SpatialRecordPolygonRequest("NewAuthKey", polygonWkt);

                    var actualRequest = JsonConvert.DeserializeObject<SpatialRecordPolygonRequest>(requestContent);

                    Assert.True(
                        new GenericEqualityComparer<SpatialRecordPolygonRequest>().Equals(
                            expectedRequest,
                            actualRequest));

                    return new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(
                            SwsSamples.SpatialRecordSuccess, Encoding.Unicode, "application/json")
                    };
                });

            this.sut.GetSpatialRecordParcels(polygonWkt);
        }

        [Theory(Skip = "External web service call, run manually.")]
        [InlineData("Idaho", "POLYGON((-112.04184651374817 43.49312138312793,-112.04257071018219 43.49218348707646,-112.03920185565948 43.49085639765385,-112.03851521015167 43.491767072127324,-112.04184651374817 43.49312138312793))", 41, 0)]
        [InlineData("Kansas", "POLYGON((-94.6085661649704 39.105142361657066,-94.60488617420197 39.10517150078678,-94.60556209087372 39.10362711031401,-94.60846424102783 39.10392267013844,-94.6085661649704 39.105142361657066))", 24, 20)]
        [InlineData("Montana", "POLYGON((-108.54085296392441 45.77408241527412,-108.53938847780228 45.77408054446194,-108.53931605815887 45.7735791645344,-108.54086101055145 45.77360348530656,-108.54085296392441 45.77408241527412))", 8, 0)]
        [InlineData("Texas", "POLYGON((-96.82873249053955 32.8216640890017,-96.82787418365479 32.820996894866276,-96.82874858379364 32.8204423986301,-96.82948887348175 32.82102845145856,-96.82873249053955 32.8216640890017))", 13, 13)]
        public void GetSpatialRecordParcelsExcludingNonSolicitationStatesFilterResults(
            string state, string polygonWkt, int unfilteredCount, int filteredCount)
        {
            this.sut = new SwsClient(this.config.Object);

            var parcels = this.sut.GetSpatialRecordParcels(polygonWkt);

            Assert.Equal(unfilteredCount, parcels.Length);

            var limitedParcels = this.sut.GetSpatialRecordParcels(
                polygonWkt: polygonWkt, excludeNonSolicitationStates: true);

            Assert.Equal(filteredCount, limitedParcels.Length);
        }

        [Fact]
        public void GetSpatialRecordParcelsExcludingNonSolicitationStatesReturnsFilteredResults()
        {
            var polygonWkt = "POLYGON((-112.04184651374817 43.49312138312793,-112.04257071018219 43.49218348707646,-112.03920185565948 43.49085639765385,-112.03851521015167 43.491767072127324,-112.04184651374817 43.49312138312793))";
            var requestCount = 0;

            this.fakeResponseHandler.AddFakePostResponse(
                new Uri(string.Format(
                    "{0}parcels",
                    this.config.Object.EndpointUrl)),
                (requestContent) =>
                {
                    requestCount++;
                    Assert.InRange(requestCount, 1, 2);

                    var actualRequest = JsonConvert.DeserializeObject<SpatialRecordPolygonRequest>(requestContent);
                    var expectedRequest = new SpatialRecordPolygonRequest(AuthKey, polygonWkt, requestCount);

                    Assert.True(
                        new GenericEqualityComparer<SpatialRecordPolygonRequest>().Equals(
                            expectedRequest,
                            actualRequest));

                    return new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(
                            (requestCount == 1) ?
                                SwsSamples.SpatialRecordLargePage1 : SwsSamples.SpatialRecordLargePage2,
                            Encoding.Unicode,
                            "application/json")
                    };
                });

            var response = this.sut.GetSpatialRecordParcels(AuthKey, polygonWkt, excludeNonSolicitationStates: true);

            Assert.Equal(30, response.Length);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">
        /// <c>true</c> to release both managed and unmanaged resources;
        /// <c>false</c> to release only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.sut.Dispose();
                    this.fakeResponseHandler.Dispose();
                }

                this.disposed = true;
            }
        }

        private void AddFakeAuthenticateSuccessResponse()
        {
            this.fakeResponseHandler.AddFakePostResponse(
                new Uri(this.config.Object.EndpointUrl + "authenticate"),
                (requestContent) =>
                {
                    var expectedRequest = new AuthRequest(this.config.Object.Username, this.config.Object.Password);
                    var actualRequest = JsonConvert.DeserializeObject<AuthRequest>(requestContent);

                    Assert.True(new GenericEqualityComparer<AuthRequest>().Equals(expectedRequest, actualRequest));

                    return new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(
                            SwsSamples.AuthenticateSuccess, Encoding.Unicode, "application/json")
                    };
                });
        }
    }
}
