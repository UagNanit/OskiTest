using System.Collections.Generic;

namespace OskiTest.Models
{
#pragma warning disable CS1591
    public class Role
    {
        public string? Id { get; set; }
        public string?  RoleName { get; set; }
        public virtual List<User> Users { get; set; } = new();
       
    }
}
