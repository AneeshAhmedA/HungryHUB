using HungryHUB.Database;
using HungryHUB.Entity;

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
                existingOrder.OrderDate = updatedOrder.OrderDate;

                _context.SaveChanges();
            }
        }

        public void DeleteOrder(string orderId)
        {
            var order = _context.Orders.Find(orderId);

            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
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
