using System.ComponentModel.DataAnnotations;

namespace OskiTest.Models.ViewModels
{
    /// <summary>
    /// Registration information 
    /// </summary>
    public class RegisterViewModel
    {
        /// <summary>
        /// User name 
        /// </summary>
        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string? Username { get; set; }

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
        [StringLength(60, MinimumLength = 6)]
        public string? Password { get; set; }


    }
}
