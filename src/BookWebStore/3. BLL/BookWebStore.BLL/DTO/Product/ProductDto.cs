using BookWebStore.BLL.DTO.Category;
using BookWebStore.BLL.DTO.CoverType;
using System.ComponentModel.DataAnnotations;

namespace BookWebStore.BLL.DTO.Product
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
        public double Price { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Display(Name = "Category Id")]
        public Guid CategoryId { get; set; }

        public CategoryDto Category { get; set; }

        public Guid CoverTypeId { get; set; }

        public CoverTypeDto CoverType { get; set; }
    }
}