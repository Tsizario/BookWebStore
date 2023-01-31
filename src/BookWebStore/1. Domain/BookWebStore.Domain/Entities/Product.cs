using BookWebStore.Domain.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace BookWebStore.Domain.Entities
{
    public class Product : DbEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string ISBN { get; set; }

        public string Author { get; set; }

        public double Price { get; set; }

        public Guid ImageId { get; set; }

        public Image Image { get; set; }

        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

        public Guid CoverTypeId { get; set; }

        public CoverType CoverType { get; set; }
    }
}
