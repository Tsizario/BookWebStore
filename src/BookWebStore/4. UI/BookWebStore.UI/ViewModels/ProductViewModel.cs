using BookWebStore.BLL.DTO.Product;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookWebStore.UI.ViewModels
{
    public class ProductViewModel
    {
        public ProductDto ProductDto { get; set; }

        public IEnumerable<SelectListItem> CategoryList { get; set; }

        public IEnumerable<SelectListItem> CoverTypeList { get; set; }
    }
}
