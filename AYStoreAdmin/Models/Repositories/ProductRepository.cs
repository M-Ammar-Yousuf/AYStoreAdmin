
using Microsoft.EntityFrameworkCore;

namespace AYStoreAdmin.Models.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AYStoreDbContext _dbContext;

        public ProductRepository(AYStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _dbContext.Products.OrderBy(o => o.ProductId).ToListAsync();
        }

        public async Task<Product?> GetProductDetailsByIdAsync(int? id)
        {
            return await _dbContext.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.ProductId == id);
        }
    }
}
