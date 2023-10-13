namespace OskiTest.Models.ViewModels
{
    public class UserViewModel
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public bool IsAdmin { get; set; }
        public List<Test> Tests { get; set; } = new List<Test>();

    }
}
