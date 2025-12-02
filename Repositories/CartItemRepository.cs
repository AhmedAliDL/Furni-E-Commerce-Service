using Furni_E_Commerce_Service.Context;
using Furni_E_Commerce_Service.Models;
using Furni_E_Commerce_Service.Repositories.Contracts;

namespace Furni_E_Commerce_Service.Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly AppDbContext _context;

        public CartItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddItems(CartItems cartItems)
        {
            _context.CartItems.Add(cartItems);
            _context.SaveChanges();
        }
        public CartItems GetCartItemById(int cartItemId)
        {
            return _context.CartItems.FirstOrDefault(ci => ci.CartItemId == cartItemId)!;
        }
        
        public CartItems GetCartItemByCartId(int cartId)
        {
            return _context.CartItems.FirstOrDefault(ci => ci.ShoppingCartId == cartId)!;
        }
        public bool HasCartItem(int cartId)
        {
            var cartItem = GetCartItemByCartId(cartId);
            return cartItem != null;
        }
        public void UpdateCartItemQuantity(int cartItemId)
        {
            var cartItme = GetCartItemById(cartItemId);
            cartItme.Quantity++;
            _context.SaveChanges();
        }

    }
}
