using BookWebStore.Domain.Abstractions;

namespace BookWebStore.Domain.Entities
{
    public class CoverType : DbEntity
    {
        public string Name { get; set; }
    }
}
