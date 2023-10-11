namespace OskiTest.Models
{
    public class Anser : IEntityBase
    {
        public string? Id { get; set; }
        public string? TextAnser { get; set; }
        public bool isCorrect { get; set; }
        public string QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}
