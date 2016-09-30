namespace CoreLogic.Services.Sws
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines a string array returned by PxPoint.
    /// </summary>
    public class PxPointStringArray
    {
        /// <summary>
        /// Gets or sets the string values.
        /// </summary>
        [JsonProperty(PropertyName = "string")]
        public string[] Values { get; set; }
    }
}