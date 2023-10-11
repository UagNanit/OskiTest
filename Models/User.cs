using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace OskiTest.Models
{
    public class User : IEntityBase
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? RoleId { get; set; }
        public virtual Role? Role { get; set; }

        public List<Test> Tests { get; set; }
        public User()
        {
            Tests = new List<Test>();
        }
    }
}