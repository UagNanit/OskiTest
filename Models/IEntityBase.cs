using System.ComponentModel.DataAnnotations;

namespace OskiTest.Models
{
    public interface IEntityBase
    {
        string Id { get; set; }
    }
}