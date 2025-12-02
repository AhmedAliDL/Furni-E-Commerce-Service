using Furni_E_Commerce_Service.Models;
using Furni_E_Commerce_Service.Repositories;
using Furni_E_Commerce_Service.Repositories.Contracts;
using Furni_E_Commerce_Service.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Furni_E_Commerce_Service.Controllers
{
    public class CheckoutController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly IProductCartItemRepository _productCartItemRepository;
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderItemsRepository _orderItemsRepository;


        public CheckoutController(UserManager<User> userManager, IProductCartItemRepository productCartItemRepository, IShoppingCartRepository shoppingCartRepository, IOrderRepository orderRepository, IPaymentRepository paymentRepository, IProductRepository productRepository,IOrderItemsRepository orderItemsRepository)
        {
            _userManager = userManager;
            _productCartItemRepository = productCartItemRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _orderRepository = orderRepository;
            _paymentRepository = paymentRepository;
            _productRepository = productRepository;
            _orderItemsRepository = orderItemsRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserOrder checkoutModel)
        {

            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            var shoppingCart = _shoppingCartRepository.GetCartByUserId(user.Id);
            var productsCartItems = _productCartItemRepository.GetProductsInShoppingCart(shoppingCart.CartId);

            checkoutModel.Products = productsCartItems.Products;
            checkoutModel.CartItemsId = productsCartItems.CartItemsId;

            if(checkoutModel.Products.Count > 0)
                 return View(checkoutModel);
            return RedirectToAction("Index","ShoppingCart");
        }
        [HttpPost]
        public async Task<IActionResult> PlaceOrder(UserOrder orderPlacement)
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            var shoppingCart = _shoppingCartRepository.GetCartByUserId(user.Id);
            var productsCartItems = _productCartItemRepository.GetProductsInShoppingCart(shoppingCart.CartId);

            orderPlacement.Products = productsCartItems.Products;
            orderPlacement.CartItemsId = productsCartItems.CartItemsId;
            orderPlacement.Address = orderPlacement.Address ?? user.Address;

            //status of payment 
            var paymentStatus = "";
            var paymentMethod = "";
            if (orderPlacement.Products.Count > 0 && orderPlacement.CVV is not null)
            {
                paymentStatus = "Completed";
                paymentMethod = "Visa";
            }
            else if (orderPlacement.Products.Count > 0 && orderPlacement.CVV is null)
            {
                paymentStatus = "Pending";
                paymentMethod = "Cash";
            }
            else if (orderPlacement.CVV is null)
            {
                paymentStatus = "Cancelled";
                paymentMethod = "Cash";
            }
            else
            {
                paymentStatus = "Cancelled";
                paymentMethod = "Visa";

            }
            var orderStatus = orderPlacement.Products.Count > 0 ? "Processing" : "Cancelled";
            //add an order
            var order = new Orders
            {
                UserId = user.Id,
                TotalAmount = orderPlacement.TotalPrice,
                OrderStatus = orderStatus,
                ShippingAddress = orderPlacement.Address,
                PaymentStatus = paymentStatus,
                CouponDiscount = orderPlacement.OrderDiscount

            };

            _orderRepository.AddOrder(order);

            //add orders` items
            var lastOrderOfUser = _orderRepository.GetLastOrder(user.Id);
            List<OrderItems> orderItems = new();
            int totalQuantity = 0;
            foreach (var product in orderPlacement.Products)
            {
                var choosenQuantity = orderPlacement.ChoosenQuantity.FirstOrDefault(cq => cq.ProductId == product.ProductId)!.ProductQuantity;
                totalQuantity += choosenQuantity;
                double productPrice = 0.0d;
                double discount = lastOrderOfUser.CouponDiscount;
                if (discount != 0) productPrice = product.Price - (product.Price * discount / 100.0);
                productPrice = productPrice == 0 ? product.Price : productPrice;
                orderItems.Add(
                    new OrderItems
                    {
                        OrderId = lastOrderOfUser.OrderId,
                        ProductId = product.ProductId,
                        Quantity = choosenQuantity,
                        UnitPrice = productPrice,
                    }
                    );

                if (paymentStatus != "Cancelled" && orderStatus != "Cancelled")
                {
                    if(product.IsActive)
                         _productRepository.RemoveStockQuantity(product, choosenQuantity);

                    _productCartItemRepository.DeleteProductsItems(product.ProductId, orderPlacement.CartItemsId);
                }
            }
            _orderItemsRepository.AddOrderItems(orderItems);
            //add payment 
            var payment = new Payments
            {
                OrderId = lastOrderOfUser.OrderId,
                PaymentMethod = paymentMethod,
                Amount = totalQuantity,
                PaymentStatus = paymentStatus
            };
            _paymentRepository.AddPayment(payment);

            if (orderPlacement.Products.Count > 0)
                return RedirectToAction("ThankYou");
            return RedirectToAction("Index", "ShoppingCart");
        }

        public IActionResult ThankYou()
        {
            return View();
        }
    }

}
