namespace OskiTest.Models
{
    public class UserTests : IEntityBase
    {
        public string? Id { get; set; }
        public int? TestScore { get; set; } = 0;
        public string? UserId { get; set; }
        public virtual User? User { get; set; }
        public string? TestId { get; set; }
        public virtual Test? Test { get; set; }
    }
}
