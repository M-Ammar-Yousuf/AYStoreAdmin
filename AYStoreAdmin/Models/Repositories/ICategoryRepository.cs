namespace AYStoreAdmin.Models.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category?> GetCategoryDetailsByIdAsync(int? id);
    }
}
