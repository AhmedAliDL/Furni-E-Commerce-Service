using Furni_E_Commerce_Service.Models;

namespace Furni_E_Commerce_Service.Repositories.Contracts
{
    public interface IOrderItemsRepository : IAddScoped
    {
        void AddOrderItems(List<OrderItems> orderItems);
        int GetQuantityForSpecificOrder(int orderId);
        List<OrderItems> GetOrderItemsByOrderId(int orderId);
        void DeleteOrderItem(OrderItems orderItem);
        void UpdateQuantity(int orderId, int quantity);
    }
}
