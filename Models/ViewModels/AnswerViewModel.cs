using System.ComponentModel.DataAnnotations;

namespace OskiTest.Models.ViewModels
{
    /// <summary>
    /// Answer information
    /// </summary>
    public class AnswerViewModel
    {
        /// <summary>
        /// Answer id
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Text answer 
        /// </summary>
        public string? TextAnswer { get; set; }
        /// <summary>
        /// Question id of answer
        /// </summary>
        public string? QuestionId { get; set; }
    }
}
