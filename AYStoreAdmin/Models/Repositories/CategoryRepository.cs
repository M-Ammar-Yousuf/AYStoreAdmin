
using Microsoft.EntityFrameworkCore;

namespace AYStoreAdmin.Models.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AYStoreDbContext _dbContext;

        public CategoryRepository(AYStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _dbContext.Categories.OrderBy(o => o.CategoryId).ToListAsync();   
        }

        public async Task<Category?> GetCategoryDetailsByIdAsync(int? id)
        {
            return await _dbContext.Categories.Include(i => i.Products).FirstOrDefaultAsync(f=> f.CategoryId == id);
        }
    }
}
