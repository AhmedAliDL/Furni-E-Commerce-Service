using Furni_E_Commerce_Service.Models;
using Furni_E_Commerce_Service.ViewModels;

namespace Furni_E_Commerce_Service.Repositories.Contracts
{
    public interface IProductCartItemRepository : IAddScoped
    {
        void AddProductsCartItem(ProductsCartItems productsCartItems);
        bool HasProductsCartItem(int productId, int cartItemsid);
        void UpdateItemQuantity(int productId, int cartItemsid, int newQuantity);
        UserOrder GetProductsInShoppingCart(int shoppingCartId);
        void DeleteProductsItems(int productId, int cartItemsid);
        ProductsCartItems GetProductsCartItems(int productId, int cartItemsid);
    }
}
