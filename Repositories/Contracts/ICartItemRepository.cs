using Furni_E_Commerce_Service.Models;
using Microsoft.CodeAnalysis;

namespace Furni_E_Commerce_Service.Repositories.Contracts
{
    public interface ICartItemRepository : IAddScoped
    {
        void AddItems(CartItems cartItems);
        CartItems GetCartItemById(int CartItemId);
        bool HasCartItem(int CartId);
        CartItems GetCartItemByCartId(int CartId);
        void UpdateCartItemQuantity(int cartItemId);
    }
}
