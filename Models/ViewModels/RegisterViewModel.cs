using System.ComponentModel.DataAnnotations;

namespace OskiTest.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string? Username { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 6)]
        public string? Password { get; set; }


    }
}
