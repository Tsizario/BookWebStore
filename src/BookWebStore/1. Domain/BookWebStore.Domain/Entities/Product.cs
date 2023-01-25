using BookWebStore.Domain.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace BookWebStore.Domain.Entities
{
    public class Product : DbEntity
    {
        public string Title { get; set; }

        public int Description { get; set; }

        public string ISBN { get; set; }

        public string Author { get; set; }

        public double Price { get; set; }

        public string ImageUrl { get; set; }

        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

        public Guid CoverTypeId { get; set; }

        public CoverType CoverType { get; set; }
    }
}
