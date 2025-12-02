using Furni_E_Commerce_Service.Models;
using Furni_E_Commerce_Service.Repositories.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Furni_E_Commerce_Service.Controllers
{
    public class ShopController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IProductRepository _productRepository;
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IProductCartItemRepository _productCartItemRepository;

        public ShopController(UserManager<User> userManager,IProductRepository productRepository,IShoppingCartRepository shoppingCartRepository,ICartItemRepository cartItemRepository,IProductCartItemRepository productCartItemRepository)
        {
            _userManager = userManager;
            _productRepository = productRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _cartItemRepository = cartItemRepository;
            _productCartItemRepository = productCartItemRepository;
        }
        public IActionResult Index()
        {
            var products = _productRepository.GetAllProducts();
            return View(products);
        }
        [HttpPost]
        public async Task<IActionResult> AddCartItem(int productId)
        {
            var product = _productRepository.GetProductsById(productId);
            if (product.IsActive)
            {
                var user = await _userManager.FindByEmailAsync(User.Identity.Name);
                string userId = "";
                if (user != null) userId = user.Id;

                var foundUser = _shoppingCartRepository.UserHasCart(userId);
                if (!foundUser)
                {
                    var shoppingCart = new ShoppingCart
                    {
                        UserId = userId,
                    };
                    _shoppingCartRepository.CreateCart(shoppingCart);
                }
                var userCart = _shoppingCartRepository.GetCartByUserId(userId);

                var foundCartItem = _cartItemRepository.HasCartItem(userCart.CartId);
                if (!foundCartItem)
                {
                    var cartItem = new CartItems
                    {
                        ShoppingCartId = userCart.CartId,
                    };
                    _cartItemRepository.AddItems(cartItem);
                }
                var userCartItem = _cartItemRepository.GetCartItemByCartId(userCart.CartId);

                _cartItemRepository.UpdateCartItemQuantity(userCartItem.CartItemId);

                var foundProductsCartItems = _productCartItemRepository
                                                 .HasProductsCartItem(productId, userCartItem.CartItemId);

                if (foundProductsCartItems)
                {
                    _productCartItemRepository.UpdateItemQuantity(productId, userCartItem.CartItemId, 1);
                }
                else
                {
                    var productsCartItem = new ProductsCartItems
                    {
                        ProductsId = productId,
                        CartItemsId = userCartItem.CartItemId,
                        ItemQuantity = 1
                    };
                    _productCartItemRepository.AddProductsCartItem(productsCartItem);
                }
                return RedirectToAction("Index", "ShoppingCart");
            }
            return BadRequest();
        }
        public IActionResult ProductDetails(int productId)
        {
            var product = _productRepository.GetProductsById(productId);

            return View(product);
        }

    }
}
