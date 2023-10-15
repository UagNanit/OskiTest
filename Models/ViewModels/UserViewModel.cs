namespace OskiTest.Models.ViewModels
{
    /// <summary>
    /// User information
    /// </summary>
    public class UserViewModel
    {
        /// <summary>
        /// User id
        /// </summary>
        public string? Id { get; set; }
        /// <summary>
        /// User name
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// List of user tests
        /// </summary>
        public List<TestViewModel> Tests { get; set; } = new List<TestViewModel>();

    }
}
