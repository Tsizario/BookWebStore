using AspNetCoreHero.ToastNotification.Abstractions;
using BookWebStore.BLL.DTO.CoverType;
using BookWebStore.BLL.Services.CoverTypeService;
using BookWebStore.Domain.Constants;
using Microsoft.AspNetCore.Mvc;

namespace BookWebStore.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly ICoverTypeService _coverTypes;
        private readonly ILogger<CategoryController> _logger;
        private readonly INotyfService _toastNotification;

        public CoverTypeController(ICoverTypeService coverTypes,
            ILogger<CategoryController> logger,
            INotyfService toastNotification)
        {
            _coverTypes = coverTypes;
            _logger = logger;
            _toastNotification = toastNotification;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var allCategories = await _coverTypes.GetAllTypes();

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
        public async Task<ActionResult> Create(CoverTypeDto coverType)
        {
            if (!ModelState.IsValid)
            {
                return View(coverType);
            }

            var addedItem = await _coverTypes.AddType(coverType);

            if (!addedItem.Success)
            {
                _toastNotification.Error(addedItem.Error);

                return RedirectToAction(nameof(Index));
            }

            _toastNotification.Success(Notifications.CoverTypeCreateSuccess);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> Edit(Guid? id)
        {
            var coverType = await _coverTypes.GetType(id);

            if (!coverType.Success)
            {
                return NotFound();
            }

            return View(coverType.Value);
        }

        // PUT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CoverTypeDto coverType)
        {
            if (!ModelState.IsValid)
            {
                return View(coverType);
            }

            var updatedItem = await _coverTypes.UpdateType(coverType);

            if (!updatedItem.Success)
            {
                _toastNotification.Error(updatedItem.Error);

                return RedirectToAction(nameof(Edit), updatedItem.Value);
            }

            _toastNotification.Success(Notifications.CoverTypeUpdateSuccess);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> Delete(Guid? id)
        {
            var coverType = await _coverTypes.GetType(id);

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
            var deletedItem = await _coverTypes.DeleteType(id);

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
