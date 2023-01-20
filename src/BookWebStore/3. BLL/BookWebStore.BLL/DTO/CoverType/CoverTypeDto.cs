using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
