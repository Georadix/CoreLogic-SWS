namespace CoreLogic.Services.Sws
{
    using System;

    /// <summary>
    /// Defines a client used to communicate with CoreLogic's Spatial Web Services (SWS).
    /// </summary>
    public interface ISwsClient
    {
        /// <summary>
        /// Geocodes the specified address.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns>A <see cref="PxPointGeocodeResult"/> instance.</returns>
        PxPointGeocodeResult Geocode(string address);

        /// <summary>
        /// Geocodes the specified address.
        /// </summary>
        /// <param name="authKey">The authentication key to access SWS.</param>
        /// <param name="address">The address.</param>
        /// <returns>A <see cref="PxPointGeocodeResult"/> instance.</returns>
        PxPointGeocodeResult Geocode(string authKey, string address);

        /// <summary>
        /// Gets the authorized features and operations accessible to the current SWS account.
        /// </summary>
        /// <returns>An <see cref="AuthorizedFeaturesResponse"/> instance.</returns>
        AuthorizedFeaturesResponse GetAuthorizedFeatures();

        /// <summary>
        /// Gets the authorized features and operations accessible to the current SWS account.
        /// </summary>
        /// <param name="authKey">The authentication key to access SWS.</param>
        /// <returns>An <see cref="AuthorizedFeaturesResponse"/> instance.</returns>
        AuthorizedFeaturesResponse GetAuthorizedFeatures(string authKey);

        /// <summary>
        /// Gets the spatial record parcel count within a specified polygon.
        /// </summary>
        /// <param name="polygonWkt">The polygon, in well-known text (WKT) format.</param>
        /// <param name="bundle">The bundle.</param>
        /// <param name="limitBySolicitation">Limits the parcels for which the owner can be legally solicited.</param>
        /// <returns>The number of parcels within the specified polygon.</returns>
        int GetSpatialRecordParcelCount(
            string polygonWkt,
            SpatialRecordBundle bundle = SpatialRecordBundle.SpatialRecordOGPremium,
            bool limitBySolicitation = false);

        /// <summary>
        /// Gets the spatial record parcel count within a specified polygon.
        /// </summary>
        /// <param name="authKey">The authentication key to access SWS.</param>
        /// <param name="polygonWkt">The polygon, in well-known text (WKT) format.</param>
        /// <param name="bundle">The bundle.</param>
        /// <param name="limitBySolicitation">Limits the parcels for which the owner can be legally solicited.</param>
        /// <returns>The number of parcels within the specified polygon.</returns>
        int GetSpatialRecordParcelCount(
            string authKey,
            string polygonWkt,
            SpatialRecordBundle bundle = SpatialRecordBundle.SpatialRecordOGPremium,
            bool limitBySolicitation = false);

        /// <summary>
        /// Gets the parcels within a specified polygon.
        /// </summary>
        /// <param name="polygonWkt">The polygon, in well-known text (WKT) format.</param>
        /// <param name="bundle">The bundle.</param>
        /// <param name="limitBySolicitation">Limits the parcels for which the owner can be legally solicited.</param>
        /// <returns>An array of <see cref="SpatialRecordParcel"/> instances.</returns>
        SpatialRecordParcel[] GetSpatialRecordParcels(
            string polygonWkt,
            SpatialRecordBundle bundle = SpatialRecordBundle.SpatialRecordOGPremium,
            bool limitBySolicitation = false);

        /// <summary>
        /// Gets the parcels within a specified polygon.
        /// </summary>
        /// <param name="authKey">The authentication key to access SWS.</param>
        /// <param name="polygonWkt">The polygon, in well-known text (WKT) format.</param>
        /// <param name="bundle">The bundle.</param>
        /// <param name="limitBySolicitation">Limits the parcels for which the owner can be legally solicited.</param>
        /// <returns>An array of <see cref="SpatialRecordParcel"/> instances.</returns>
        SpatialRecordParcel[] GetSpatialRecordParcels(
            string authKey,
            string polygonWkt,
            SpatialRecordBundle bundle = SpatialRecordBundle.SpatialRecordOGPremium,
            bool limitBySolicitation = false);

        /// <summary>
        /// Gets the parcels at a specified latitude/longitude.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="bundle">The bundle.</param>
        /// <param name="limitBySolicitation">Limits the parcels for which the owner can be legally solicited.</param>
        /// <returns>An array of <see cref="SpatialRecordParcel"/> instances.</returns>
        SpatialRecordParcel[] GetSpatialRecordParcels(
            double latitude,
            double longitude,
            SpatialRecordBundle bundle = SpatialRecordBundle.SpatialRecordOGPremium,
            bool limitBySolicitation = false);

        /// <summary>
        /// Gets the parcels at a specified latitude/longitude.
        /// </summary>
        /// <param name="authKey">The authentication key to access SWS.</param>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="bundle">The bundle.</param>
        /// <param name="limitBySolicitation">Limits the parcels for which the owner can be legally solicited.</param>
        /// <returns>An array of <see cref="SpatialRecordParcel"/> instances.</returns>
        SpatialRecordParcel[] GetSpatialRecordParcels(
            string authKey,
            double latitude,
            double longitude,
            SpatialRecordBundle bundle = SpatialRecordBundle.SpatialRecordOGPremium,
            bool limitBySolicitation = false);
    }
}