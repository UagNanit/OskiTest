namespace OskiTest.Models.ViewModels
{
    /// <summary>
    /// Authorization information
    /// </summary>
    public class AuthData
    {
        /// <summary>
        /// Token
        /// </summary>
        public string? Token { get; set; }
        /// <summary>
        /// Token expiration time
        /// </summary>
        public long TokenExpirationTime { get; set; }
        /// <summary>
        /// User id
        /// </summary>
        public string? Id { get; set; }
        /// <summary>
        /// User name
        /// </summary>
        public string? Name { get; set; }
    }
}