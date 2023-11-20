using HungryHUB.DTO;
using HungryHUB.Entity;
using System.Collections.Generic;

namespace HungryHUB.Service
{
    public interface IOrderService
    {
        void CreateOrder(Order order);
        void UpdateOrder(string orderId, Order updatedOrder);
        void DeleteOrder(string orderId);
        Order GetOrderById(string orderId);
        List<Order> GetAllOrders();
        List<Order> GetOrdersByUser(string userId);
    }
}
