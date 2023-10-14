namespace OskiTest.Models.ViewModels
{
    public class UserViewModel
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public List<TestViewModel> Tests { get; set; } = new List<TestViewModel>();

    }
}
