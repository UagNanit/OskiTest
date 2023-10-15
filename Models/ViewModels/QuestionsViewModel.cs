
namespace OskiTest.Models.ViewModels
{
    public class QuestionsViewModel
    {
        public string? Id { get; set; }
        public string TextQuestion { get; set; }
        public virtual List<AnswerViewModel> Answers { get; set; } = new();
    }
}
