using System.ComponentModel.DataAnnotations;

namespace OskiTest.Models.ViewModels
{
    /// <summary>
    /// Login information
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// User email
        /// </summary>
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        [Required]
        public string? Password { get; set; }
    }
}