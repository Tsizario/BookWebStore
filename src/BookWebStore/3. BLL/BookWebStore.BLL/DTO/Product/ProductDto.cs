using BookWebStore.BLL.DTO.Category;
using BookWebStore.BLL.DTO.CoverType;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace BookWebStore.BLL.DTO.Product
{
    public class ProductDto
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Author { get; set; }

        [Required]
        [Range(1, 10000)]
        public double Price { get; set; }

        [ValidateNever]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = "Category Id")]
        public Guid CategoryId { get; set; }

        [ValidateNever]
        public CategoryDto Category { get; set; }

        [Required]
        [Display(Name = "Cover type Id")]
        public Guid CoverTypeId { get; set; }

        [ValidateNever]
        public CoverTypeDto CoverType { get; set; }
    }
}