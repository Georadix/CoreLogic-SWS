namespace CoreLogic.Services.Sws
{
    using System.Configuration;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents the configuration for CoreLogic's Spatial Web Services (SWS).
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SwsConfigurationSection : ConfigurationSection, ISwsConfig
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwsConfigurationSection"/> class.
        /// </summary>
        protected SwsConfigurationSection()
        {
        }

        /// <summary>
        /// Gets the endpoint URL.
        /// </summary>
        [ConfigurationProperty("endpointUrl", IsRequired = true)]
        public string EndpointUrl
        {
            get { return (string)this["endpointUrl"]; }
        }

        string ISwsConfig.EndpointUrl
        {
            get { return this.EndpointUrl; }
        }

        string ISwsConfig.Password
        {
            get { return this.Password; }
        }

        int ISwsConfig.Timeout
        {
            get { return this.Timeout; }
        }

        string ISwsConfig.Username
        {
            get { return this.Username; }
        }

        /// <summary>
        /// Gets the password.
        /// </summary>
        [ConfigurationProperty("password", IsRequired = true)]
        public string Password
        {
            get { return (string)this["password"]; }
        }

        /// <summary>
        /// Gets the number of seconds to wait before a request times out.
        /// </summary>
        [ConfigurationProperty("timeout", IsRequired = false, DefaultValue = 30)]
        public int Timeout
        {
            get { return (int)this["timeout"]; }
        }

        /// <summary>
        /// Gets the username.
        /// </summary>
        [ConfigurationProperty("username", IsRequired = true)]
        public string Username
        {
            get { return (string)this["username"]; }
        }
    }
}