
namespace OskiTest.Models.ViewModels
{
    /// <summary>
    /// Test information for user 
    /// </summary>
    public class TestViewModel 
    {
        /// <summary>
        /// Tests id
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Tests name
        /// </summary>
        public string? TestName { get; set; }

        /// <summary>
        /// Tests description
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// User test score 
        /// </summary>
        public int? TestScore { get; set; }
    }
}
