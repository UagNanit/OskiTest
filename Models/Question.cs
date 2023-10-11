using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;

namespace OskiTest.Models
{
    public class Question : IEntityBase
    {
        public string? Id { get; set; }
        public string? TextQuestion { get; set; }
        public string TestId { get; set; }
        public virtual Test Test { get; set; }
        public virtual List<Anser> Ansers { get; set; }
        public Question()
        {
            Ansers = new List<Anser>();
        }
    }
}
