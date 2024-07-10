namespace AYStoreAdmin.Models.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductDetailsByIdAsync(int? id);
    }
}
