
using Microsoft.EntityFrameworkCore;

namespace AYStoreAdmin.Models.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AYStoreDbContext _dbContext;

        public OrderRepository(AYStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersWithDetailsAsync()
        {
            return await _dbContext.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .OrderBy(o => o.OrderId)
                .ToListAsync();
        }

        public async Task<Order?> GetOrderDetailsByIdAsync(int? orderId)
        {
            if (orderId != null)
            {
                return await _dbContext.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .Where(f => f.OrderId == orderId)
                .OrderBy(od => od.OrderId)
                .FirstOrDefaultAsync();
            }
            return null;
        }
    }
}
