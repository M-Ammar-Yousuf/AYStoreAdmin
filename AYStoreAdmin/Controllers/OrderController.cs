using AYStoreAdmin.Models;
using AYStoreAdmin.Models.Repositories;
using AYStoreAdmin.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AYStoreAdmin.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IActionResult> Index(int? orderId, int? orderDetailId)
        {
            OrderIndexViewModel orderIndexViewModel = new OrderIndexViewModel()
            {
                Orders = await _orderRepository.GetAllOrdersWithDetailsAsync(),
            };

            if (orderId != null)
            {
                Order selectedOrder = orderIndexViewModel.Orders.Where(o => o.OrderId == orderId).Single();
                orderIndexViewModel.OrderDetails = selectedOrder.OrderDetails;
                orderIndexViewModel.SelectedOrderId = orderId;
            }

            if (orderDetailId != null)
            {
                OrderDetail selectedOrderDetail = orderIndexViewModel.OrderDetails.Where(od => od.OrderDetailId ==  orderDetailId).Single();
                orderIndexViewModel.Products = new List<Product> { selectedOrderDetail.Product };
                orderIndexViewModel.SelectedOrderDetailId = orderDetailId;
            }

            return View(orderIndexViewModel);
        }

        public async Task<IActionResult> Details(int? orderId)
        {
            var result = await _orderRepository.GetOrderDetailsByIdAsync(orderId);
            return View(result);
        }
    }
}
