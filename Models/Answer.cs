using System.ComponentModel.DataAnnotations;

namespace OskiTest.Models
{
#pragma warning disable CS1591
    public class Answer : IEntityBase
    {
        [Key]
        public string? Id { get; set; }
        public string? TextAnswer { get; set; }
        public string? QuestionId { get; set; }
        public virtual Question? Question { get; set; }
    }
}
