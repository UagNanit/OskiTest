namespace OskiTest.Models.ViewModels
{
    public class UserAnswersViewModel
    {
        public string UserId { get; set; }
        public string TestId { get; set; }
        public List<AnswersViewModel> Answers { get; set; }
      
    }
}
