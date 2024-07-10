using AYStoreAdmin.Models.Repositories;
using AYStoreAdmin.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AYStoreAdmin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Index()
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel()
            {
                Categories = await _categoryRepository.GetAllCategoriesAsync(),
            };

            return View(categoryViewModel);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = await _categoryRepository.GetCategoryDetailsByIdAsync(id.Value);
            return View(category);
        }
    }
}
