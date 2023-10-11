namespace OskiTest.Models
{
    public class Anser : IEntityBase
    {
        public string? Id { get; set; }
        public string? TextAnser { get; set; }
        public bool isCorrect { get; set; }
    }
}
