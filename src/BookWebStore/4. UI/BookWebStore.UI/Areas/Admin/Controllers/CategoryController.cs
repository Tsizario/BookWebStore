using AspNetCoreHero.ToastNotification.Abstractions;
using BookWebStore.BLL.DTO.Category;
using BookWebStore.BLL.Services.CategoryService;
using BookWebStore.Domain.Constants;
using Microsoft.AspNetCore.Mvc;

namespace BookWebStore.UI.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categories;
        private readonly ILogger<CategoryController> _logger;
        private readonly INotyfService _toastNotification;

        public CategoryController(ICategoryService categories,
            ILogger<CategoryController> logger,
            INotyfService toastNotification)
        {
            _categories = categories;
            _logger = logger;
            _toastNotification = toastNotification;
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
                _toastNotification.Error(Errors.CategorySameNumber);

                //ModelState.AddModelError("Name", "The order's number cannot exactly match the same name");

                return View(category);
            }

            var addedItem = await _categories.AddCategory(category);

            if (!addedItem.Success)
            {
                _toastNotification.Error(addedItem.Error);

                return RedirectToAction(nameof(Index));
            }

            _toastNotification.Success(Notifications.CategoryCreateSuccess);

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
                _toastNotification.Error(Errors.CategorySameNumber);
                //// set the same name as on view/page (for example, 'Name' property of model as here)
                //ModelState.AddModelError("Name", "The order's number cannot exactly match the name");

                return View(category);
            }

            var updatedItem = await _categories.UpdateCategory(category);

            if (!updatedItem.Success)
            {
                _toastNotification.Error(updatedItem.Error);

                return RedirectToAction(nameof(Edit), updatedItem.Value);
            }

            _toastNotification.Success(Notifications.CategoryUpdateSuccess);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> Delete(Guid? id)
        {
            var category = await _categories.GetCategory(id);

            if (!category.Success)
            {
                return RedirectToAction(nameof(Index));
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
                _toastNotification.Error(deletedItem.Error);

                return View(nameof(Index));
            }

            _toastNotification.Success(Notifications.CategoryDeleteSuccess);

            return RedirectToAction(nameof(Index));
        }
    }
}
