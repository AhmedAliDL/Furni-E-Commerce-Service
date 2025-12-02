using Furni_E_Commerce_Service.Context;
using Furni_E_Commerce_Service.Models;
using Furni_E_Commerce_Service.Repositories.Contracts;

namespace Furni_E_Commerce_Service.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly AppDbContext _context;

        public ShoppingCartRepository(AppDbContext context)
        {
            _context = context;
        }
        public bool UserHasCart(string userId)
        {
            var shoppingCart = _context.ShoppingCart.FirstOrDefault(sc => sc.UserId == userId);

            return shoppingCart != null;
        }
        public void CreateCart(ShoppingCart shoppingCart)
        {
            _context.ShoppingCart.Add(shoppingCart);
            _context.SaveChanges();
        }
        public ShoppingCart GetCartByUserId(string userId)
        {
            return _context.ShoppingCart.FirstOrDefault(sc => sc.UserId == userId)!;
        }
    }
}
