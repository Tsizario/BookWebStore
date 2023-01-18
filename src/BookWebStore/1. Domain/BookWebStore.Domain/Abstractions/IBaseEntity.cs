using System.ComponentModel.DataAnnotations;

namespace BookWebStore.Domain.Abstractions
{
    public interface IBaseEntity
    {
        [Key]
        Guid Id { get; set; }
    }
}