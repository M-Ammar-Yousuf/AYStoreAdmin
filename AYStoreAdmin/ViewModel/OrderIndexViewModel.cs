﻿using AYStoreAdmin.Models;

namespace AYStoreAdmin.ViewModel
{
    public class OrderIndexViewModel
    {
        public IEnumerable<Order>? Orders { get; set; }
        public IEnumerable<OrderDetail>? OrderDetails { get; set; }
        public IEnumerable<Product>? Products { get; set; }
        public int? SelectedOrderId { get; set; }
        public int? SelectedOrderDetailId { get; set; }
    }
}
