namespace CoreLogic.Services.Sws
{
    /// <summary>
    /// Represents an authentication request.
    /// </summary>
    public class AuthRequest
    {
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string Username { get; set; }
    }
}