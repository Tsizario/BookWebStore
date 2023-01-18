using System.ComponentModel.DataAnnotations;

namespace BookWebStore.Domain.Abstractions
{
    public interface IDbEntity
    {
        [Key]
        Guid Id { get; set; }
    }
}