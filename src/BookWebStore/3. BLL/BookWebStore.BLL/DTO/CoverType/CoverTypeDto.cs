using System.ComponentModel.DataAnnotations;

namespace BookWebStore.BLL.DTO.CoverType
{
    public class CoverTypeDto
    {
        public Guid Id { get; set; }

        [Display(Name = "Cover type")]
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
