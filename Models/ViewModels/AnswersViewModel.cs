using System.ComponentModel.DataAnnotations;

namespace OskiTest.Models.ViewModels
{

    /// <summary>
    /// Selected answers
    /// </summary>
    public class AnswersViewModel
    {
        /// <summary>
        /// Question id
        /// </summary>
        [Required]
        public string? QuestionId { get; set; }
        /// <summary>
        /// Selected answer id
        /// </summary>
        [Required]
        public string? AnswerId { get; set; }
    }
}
