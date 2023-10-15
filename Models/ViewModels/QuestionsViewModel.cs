
namespace OskiTest.Models.ViewModels
{
    /// <summary>
    /// Question information
    /// </summary>
    public class QuestionsViewModel
    {
        /// <summary>
        /// Question Id
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Text question
        /// </summary>
        public string? TextQuestion { get; set; }
        /// <summary>
        ///List of answers to the question
        /// </summary>
        public virtual List<AnswerViewModel> Answers { get; set; } = new();
    }
}
