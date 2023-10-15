namespace OskiTest.Models
{
#pragma warning disable CS1591
    public class UserTest : IEntityBase
    {
        public string Id { get; set; }
        public int? TestScore { get; set; } = -1;
        public string? UserId { get; set; }
        public virtual User User { get; set; } = null!;
        public string? TestId { get; set; }
        public virtual Test Test { get; set; } = null!;

    }
}
