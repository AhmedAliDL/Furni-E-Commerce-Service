using Furni_E_Commerce_Service.Models;
using Furni_E_Commerce_Service.Repositories.Contracts;
using Furni_E_Commerce_Service.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace Furni_E_Commerce_Service.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IProductCartItemRepository _productCartItemRepository;
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartController(UserManager<User> userManager,IProductCartItemRepository productCartItemRepository,IShoppingCartRepository shoppingCartRepository)
        {
            _userManager = userManager;
            _productCartItemRepository = productCartItemRepository;
            _shoppingCartRepository = shoppingCartRepository;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            var shoppingCart = _shoppingCartRepository.GetCartByUserId(user.Id);
            var productsCartItems = _productCartItemRepository.GetProductsInShoppingCart(shoppingCart.CartId);
           
            return View(productsCartItems);
        }
        public IActionResult DeleteProduct(int productId, int cartItemsid)
        {
            _productCartItemRepository.DeleteProductsItems(productId, cartItemsid);

            return RedirectToAction("Index", "ShoppingCart");
        }
    }
}
