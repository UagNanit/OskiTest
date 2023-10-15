using System.ComponentModel.DataAnnotations;

namespace OskiTest.Models.ViewModels
{
    /// <summary>
    /// User's answers to the questions of the selected test
    /// </summary>
    public class UserAnswersViewModel
    {
        /// <summary>
        /// User id
        /// </summary>
        [Required]
        public string? UserId { get; set; }
        /// <summary>
        /// Selected Test id
        /// </summary>
        [Required]
        public string? TestId { get; set; }
        /// <summary>
        /// User answers 
        /// </summary>
        [Required]
        public List<AnswersViewModel> Answers { get; set; }
      
    }
}
