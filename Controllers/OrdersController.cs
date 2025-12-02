using Furni_E_Commerce_Service.Models;
using Furni_E_Commerce_Service.Repositories.Contracts;
using Furni_E_Commerce_Service.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Furni_E_Commerce_Service.Controllers
{
    public class OrdersController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemsRepository _orderItemsRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IProductRepository _productRepository;

        public OrdersController(UserManager<User> userManager, IOrderRepository orderRepository, IOrderItemsRepository orderItemsRepository, IPaymentRepository paymentRepository, IProductRepository productRepository)
        {
            _userManager = userManager;
            _orderRepository = orderRepository;
            _orderItemsRepository = orderItemsRepository;
            _paymentRepository = paymentRepository;
            _productRepository = productRepository;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            var ordersForUser = _orderRepository.GetOrdersForUsers(user.Id);


            var orderList = new List<OrderShippingViewModel>();
            foreach (var order in ordersForUser)
            {
                var totalQuantity = _orderItemsRepository.GetQuantityForSpecificOrder(order.OrderId);
                TimeSpan remainingTime = order.OrderDate.AddDays(5) - DateTime.Now;
                var remainingDays = (int)Math.Ceiling(remainingTime.TotalDays);
                var orderId = order.OrderId;
                if (remainingDays == 1)
                    _orderRepository.UpdateOrderStatus(orderId, "Shipped");
                else if (remainingDays == 0)
                {
                    _orderRepository.UpdateOrderStatus(orderId, "Delivered");
                    _paymentRepository.UpdatePaymentStatus(orderId, "Completed");
                    _orderRepository.UpdatePaymentStatus(orderId, "Completed");
                }

                orderList.Add(
                    new()
                    {
                        OrderId = orderId,
                        Address = order.ShippingAddress,
                        OrderDate = order.OrderDate.Date,
                        ShippingStatus = order.OrderStatus,
                        TotalAmount = totalQuantity,
                        TotalPrice = order.TotalAmount,
                        RemainingDays = remainingDays
                    }

                    );


            }

            return View(orderList);
        }
        [HttpGet]
        public IActionResult DeleteFullOrder(int orderId)
        {
            var orderItems = _orderItemsRepository.GetOrderItemsByOrderId(orderId);
            foreach (var orderItem in orderItems)
            {
                var product = _productRepository.GetProductsById(orderItem.ProductId);
                _productRepository.AddStockQuantity(product, orderItem.Quantity);
            }
            _orderRepository.DeleteOrder(orderId);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult OrderDetails(int orderId)
        {
            var orderItems = _orderItemsRepository.GetOrderItemsByOrderId(orderId);
            var orderDetails = new List<OrderDetails>();
            foreach (var orderItem in orderItems)
            {
                var product = _productRepository.GetProductsById(orderItem.ProductId);
                var order = _orderRepository.GetOrder(orderId);

                orderDetails.Add(
                    new()
                    {
                        OrderId = orderItem.OrderId,
                        ProductId = product.ProductId,
                        ProductImage = product.ImageUrl,
                        ProductName = product.ProductName,
                        ProductPrice = orderItem.UnitPrice,
                        ProductQuantity = orderItem.Quantity,
                        ShippingStatus = order.OrderStatus
                    }

                    );
            }

            return View(orderDetails);

        }
        [HttpGet]
        public IActionResult DeleteSpecificItemFromOrder(int orderId, int productId, int quantity)
        {
            var orderItem = _orderItemsRepository.GetOrderItemsByOrderId(orderId)
                .FirstOrDefault(oi => oi.ProductId == productId && oi.Quantity == quantity)!;

            var product = _productRepository.GetProductsById(productId);
            _productRepository.AddStockQuantity(product, quantity);
            var productPrice = orderItem.UnitPrice * orderItem.Quantity;
            _orderItemsRepository.UpdateQuantity(orderItem.OrderItemId, quantity);
            _orderRepository.UpdateTotalPrice(orderId, productPrice);   
            var totalQuantity = _orderItemsRepository.GetQuantityForSpecificOrder(orderId);
            if (totalQuantity <= 0) _orderRepository.DeleteOrder(orderId);
            else
                _orderItemsRepository.DeleteOrderItem(orderItem);
            return RedirectToAction("Index");
        }
    }
}
