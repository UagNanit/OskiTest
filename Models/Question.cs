using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OskiTest.Models
{
#pragma warning disable CS1591
    public class Question : IEntityBase
    {
        public string Id { get; set; }
        public string TextQuestion { get; set; }
        public string TestId { get; set; }
        public virtual Test Test { get; set; } = null!;
        public string CorrectAnswerId { get; set; }
        public virtual List<Answer> Answers { get; set; } = new();
    }
}
