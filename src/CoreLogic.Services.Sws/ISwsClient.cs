namespace CoreLogic.Services.Sws
{
    using System;

    /// <summary>
    /// Defines a client used to communicate with CoreLogic's Spatial Web Services (SWS).
    /// </summary>
    public interface ISwsClient
    {
        /// <summary>
        /// Gets the spatial record parcel count within a specified polygon.
        /// </summary>
        /// <param name="polygonWkt">The polygon, in well-known text (WKT) format.</param>
        /// <param name="bundle">The bundle.</param>
        /// <returns>The number of parcels within the specified polygon.</returns>
        int GetSpatialRecordParcelCount(
            string polygonWkt, SpatialRecordBundle bundle = SpatialRecordBundle.SpatialRecordOGPremium);

        /// <summary>
        /// Gets the parcels within a specified polygon.
        /// </summary>
        /// <param name="polygonWkt">The polygon, in well-known text (WKT) format.</param>
        /// <param name="bundle">The bundle.</param>
        /// <returns>An array of <see cref="SpatialRecordParcel"/> instances.</returns>
        SpatialRecordParcel[] GetSpatialRecordParcels(
            string polygonWkt, SpatialRecordBundle bundle = SpatialRecordBundle.SpatialRecordOGPremium);

        /// <summary>
        /// Gets the parcels at a specified latitude/longitude.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="bundle">The bundle.</param>
        /// <returns>An array of <see cref="SpatialRecordParcel"/> instances.</returns>
        SpatialRecordParcel[] GetSpatialRecordParcels(
            double latitude,
            double longitude,
            SpatialRecordBundle bundle = SpatialRecordBundle.SpatialRecordOGPremium);
    }
}