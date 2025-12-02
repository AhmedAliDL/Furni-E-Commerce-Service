using Furni_E_Commerce_Service.Models;

namespace Furni_E_Commerce_Service.Repositories.Contracts
{
    public interface IOrderRepository : IAddScoped
    {
        Orders GetOrder(int orderId);
        void AddOrder(Orders order);
        Orders GetLastOrder(string userId);
        List<Orders> GetOrdersForUsers(string userId);
        void UpdateOrderStatus(int orderId, string orderStatus);
        void UpdatePaymentStatus(int orderId, string paymentStatus);
        void DeleteOrder(int orderId);
        void UpdateTotalPrice(int orderId, double price);

    }
}
