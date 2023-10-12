using System.Text.Json.Serialization;

namespace OskiTest.Models
{
    public class Test : IEntityBase
    {
        public string? Id { get; set; }
        public string? TestName { get; set; }
        public string? Description { get; set; }
        public virtual List<Question> Questions { get; set; }
        public Test()
        {
            Questions = new List<Question>();
           
        }
       
        

    }
}
