using BookWebStore.BLL.DTO.Category;
using BookWebStore.BLL.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;

namespace BookWebStore.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categories;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryService _categories,
            ILogger<CategoryController> logger)
        {
            this._categories = _categories;
            _logger = logger;
        }
        
        // GET
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var allCategories = await _categories.GetAllCategories();

            if (!allCategories.Success)
            {
                return NotFound();
            }

            return View(allCategories.Value);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {           
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CategoryCreateDto category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The order's number cannot exactly match the same name");

                return View(category);
            }

            var addedItem = await _categories.AddCategory(category);

            if (!addedItem.Success)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
        
        [HttpGet]
        public async Task<ActionResult> Edit(Guid? id)
        {
            var category = await _categories.GetCategory(id);

            if (!category.Success)
            {
                return NotFound();
            }

            return View(category.Value);
        }

        // PUT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CategoryDto category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            if (category.Name == category.DisplayOrder.ToString())
            {
                // set the same name as on view/page (for example, 'Name' property of model as here)
                ModelState.AddModelError("Name", "The order's number cannot exactly match the name");

                return View(category);
            }

            var updatedItem = await _categories.UpdateCategory(category);

            if (!updatedItem.Success)
            {
                return RedirectToAction("Edit", updatedItem.Value);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Delete(Guid? id)
        {
            var category = await _categories.GetCategory(id);

            if (!category.Success)
            {
                return RedirectToAction("Index");
            }

            return View(category.Value);
        }

        // DELETE
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deletedItem = await _categories.DeleteCategory(id);

            if (!deletedItem.Success)
            {
                return View(nameof(Index));
            }

            return RedirectToAction("Index");
        }
    }
}
