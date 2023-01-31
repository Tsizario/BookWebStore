using BookWebStore.BLL.Attributes;
using BookWebStore.BLL.DTO.Product;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookWebStore.UI.ViewModels
{
    public class ProductViewModel
    {
        public ProductDto ProductDto { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> CoverTypeList { get; set; }
    }
}
