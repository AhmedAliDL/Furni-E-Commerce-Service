using Furni_E_Commerce_Service.Context;
using Furni_E_Commerce_Service.Models;
using Furni_E_Commerce_Service.Repositories.Contracts;

namespace Furni_E_Commerce_Service.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }
        public Orders GetOrder(int orderId)
        {
            return _context.Orders.FirstOrDefault(o => o.OrderId == orderId)!;
        }
        public void AddOrder(Orders order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
        public Orders GetLastOrder(string userId)
        {
            return _context.Orders
                        .Where(o => o.UserId == userId).ToList()[^1];
        }
        public List<Orders> GetOrdersForUsers(string userId)
        {
            var orders = _context.Orders.Where(o => o.UserId == userId).ToList();
            
            return orders;
        }
        public void UpdateOrderStatus(int orderId, string orderStatus)
        {
            var order = GetOrder(orderId);
            order.OrderStatus = orderStatus;
            _context.SaveChanges();
        }
        public void UpdatePaymentStatus(int orderId, string paymentStatus)
        {
            var order = GetOrder(orderId);
            order.PaymentStatus = paymentStatus;
            _context.SaveChanges();
        }
        public void DeleteOrder(int orderId)
        {
            var order = GetOrder(orderId);
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }
        public void UpdateTotalPrice(int orderId , double price)
        {
            var order = GetOrder(orderId);
            order.TotalAmount -= price;
            _context.SaveChanges();
        }
       
    }
}
