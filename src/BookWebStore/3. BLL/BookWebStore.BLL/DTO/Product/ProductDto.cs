using BookWebStore.BLL.DTO.Category;
using BookWebStore.BLL.DTO.CoverType;
using BookWebStore.Domain.Abstractions;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookWebStore.Domain.Entities
{
    public class ProductDto
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int Description { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        [Range(1, 10000)]
        public double ListPrice { get; set; }

        [Required]
        [Range(1, 10000)]
        public double Price { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public Guid CategoryId { get; set; }

        public CategoryDto Category { get; set; }

        public Guid CoverTypeId { get; set; }

        public CoverTypeDto CoverType { get; set; }
    }
}