using Furni_E_Commerce_Service.Context;
using Furni_E_Commerce_Service.Models;
using Furni_E_Commerce_Service.Repositories.Contracts;

namespace Furni_E_Commerce_Service.Repositories
{
    public class OrderItemsRepository : IOrderItemsRepository
    {
        private readonly AppDbContext _context;

        public OrderItemsRepository(AppDbContext context)
        {
            _context = context;
        }
        public OrderItems GetOrderItems(int orderItemsId)
        {
            return _context.OrderItems.FirstOrDefault(oi => oi.OrderItemId == orderItemsId)!;

        }
        public void AddOrderItems(List<OrderItems> orderItems)
        {
            _context.OrderItems.AddRange(orderItems);
            _context.SaveChanges();
        }
        public int GetQuantityForSpecificOrder(int orderId)
        {
            return _context.OrderItems.Where(oi => oi.OrderId == orderId).Sum(oi => oi.Quantity);
        }
        public List<OrderItems> GetOrderItemsByOrderId(int orderId)
        {
            return _context.OrderItems.Where(oi => oi.OrderId == orderId).ToList();
        }
        public void DeleteOrderItem(OrderItems orderItem)
        {
            _context.OrderItems.Remove(orderItem);
            _context.SaveChanges();
        }
        public void UpdateQuantity(int orderItemsId, int quantity)
        {
            var order = GetOrderItems(orderItemsId);
            order.Quantity -= quantity;
            _context.SaveChanges();
        }

    }
}
