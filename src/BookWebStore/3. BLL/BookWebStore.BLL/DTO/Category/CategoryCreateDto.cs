using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookWebStore.BLL.DTO.Category
{
    public class CategoryCreateDto
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1, 100,
            ErrorMessage = "Display Order must be between 1 and 100 only!")]
        public int DisplayOrder { get; set; }

        public DateTime Created { get; set; } = DateTime.UtcNow;
    }
}