namespace AYStoreAdmin.Models.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrdersWithDetailsAsync();
        Task<Order?> GetOrderDetailsByIdAsync(int? orderId);
    }
}
