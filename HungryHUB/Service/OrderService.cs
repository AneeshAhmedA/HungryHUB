using HungryHUB.Database;
using HungryHUB.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HungryHUB.Service
{
    public class OrderService : IOrderService
    {
        private readonly MyContext _context;

        public OrderService(MyContext context)
        {
            _context = context;
        }

        public void CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void UpdateOrder(string orderId, Order updatedOrder)
        {
            var existingOrder = _context.Orders.Find(orderId);

            if (existingOrder != null)
            {
                // Update properties based on your requirements
                existingOrder.OrderDate = updatedOrder.OrderDate;

                _context.SaveChanges();
            }
            // Handle case where order is not found
        }

        public void DeleteOrder(string orderId)
        {
            var order = _context.Orders.Find(orderId);

            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
            // Handle case where order is not found
        }

        public Order GetOrderById(string orderId)
        {
            return _context.Orders.Find(orderId);
        }

        public List<Order> GetAllOrders()
        {
            return _context.Orders.ToList();
        }

        public List<Order> GetOrdersByUser(string userId)
        {
            return _context.Orders
                .Where(o => o.UserId == userId)
                .ToList();
        }
    }
}
