using BookWebStore.Domain.Abstractions;

namespace BookWebStore.Domain.Entities
{
    public class Category : DbEntity
    {
        public string Name { get; set; }

        public int DisplayOrder { get; set; }

        public DateTime Created { get; set; }
    }
}