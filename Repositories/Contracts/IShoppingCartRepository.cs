using Furni_E_Commerce_Service.Models;

namespace Furni_E_Commerce_Service.Repositories.Contracts
{
    public interface IShoppingCartRepository : IAddScoped
    {
        bool UserHasCart(string userId);
        void CreateCart(ShoppingCart shoppingCart);
        ShoppingCart GetCartByUserId(string userId);
    }
}
