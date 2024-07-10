using AYStoreAdmin.Models.Repositories;
using AYStoreAdmin.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AYStoreAdmin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index()
        {
            ProductViewModel productViewModel = new ProductViewModel()
            {
                Products = await _productRepository.GetAllProductsAsync(),
            };
            return View(productViewModel);
        }

        public async Task<IActionResult> Details(int? productId)
        {
            if (productId == null)
            {
                return NotFound();
            }
            var product = await _productRepository.GetProductDetailsByIdAsync(productId.Value);
            return View(product);
        }
    }
}
