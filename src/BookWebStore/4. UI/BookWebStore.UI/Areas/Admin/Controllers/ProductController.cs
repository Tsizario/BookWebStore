using AspNetCoreHero.ToastNotification.Abstractions;
using BookWebStore.BLL.DTO.Product;
using BookWebStore.BLL.Services.CategoryService;
using BookWebStore.BLL.Services.ProductService;
using BookWebStore.Domain.Constants;
using BookWebStore.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookWebStore.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _products;
        private readonly ICategoryService _categories;
        private readonly ICoverTypeService _coverTypes;
        private readonly ILogger<CategoryController> _logger;
        private readonly INotyfService _toastNotification;

        public ProductController(IProductService products,
            ICategoryService categories,
            ICoverTypeService coverTypes,
            ILogger<CategoryController> logger,
            INotyfService toastNotification)
        {
            _products = products;
            _categories = categories;
            _coverTypes = coverTypes;
            _logger = logger;
            _toastNotification = toastNotification;
        }

        public IEnumerable<SelectListItem> CategoryList { get; set; }

        // GET
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var allCategories = await _products.GetAllProducts();

            if (!allCategories.Success)
            {
                return NotFound();
            }

            return View(allCategories.Value);
        }       

        [HttpGet]
        public async Task<ActionResult> CreateOrEdit(Guid? id)
        {
            var categories = await _categories.GetAllCategories();
            var coverTypes = await _coverTypes.GetAllTypes();

            ProductViewModel productViewModel = new()
            {
                ProductDto = new(),
                CategoryList = categories.Value.Select(
                    u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id.ToString()
                    }),
                CoverTypeList = coverTypes.Value.Select(
                    u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id.ToString()
                    })
            };

            if (id == null || id == Guid.Empty)
            {
                return View(productViewModel);
            }           

            return View(productViewModel);
        }

        // PUT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateOrEdit(ProductViewModel productViewModel, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return View(productViewModel);
            }

            var updatedItem = await _products.UpdateProduct(productViewModel.ProductDto);

            if (!updatedItem.Success)
            {
                _toastNotification.Error(updatedItem.Error);

                return RedirectToAction(nameof(CreateOrEdit), updatedItem.Value);
            }

            _toastNotification.Success(Notifications.CoverTypeUpdateSuccess);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> Delete(Guid? id)
        {
            var coverType = await _products.GetProduct(id);

            if (!coverType.Success)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(coverType.Value);
        }

        // DELETE
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deletedItem = await _products.DeleteType(id);

            if (!deletedItem.Success)
            {
                _toastNotification.Error(deletedItem.Error);

                return View(nameof(Index));
            }

            _toastNotification.Success(Notifications.CoverTypeDeleteSuccess);

            return RedirectToAction(nameof(Index));
        }
    }
}
