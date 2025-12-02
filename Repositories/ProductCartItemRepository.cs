using Furni_E_Commerce_Service.Context;
using Furni_E_Commerce_Service.Models;
using Furni_E_Commerce_Service.Repositories.Contracts;
using Furni_E_Commerce_Service.ViewModels;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Net;

namespace Furni_E_Commerce_Service.Repositories
{
    public class ProductCartItemRepository : IProductCartItemRepository
    {
        private readonly AppDbContext _context;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IProductRepository _productRepository;

        public ProductCartItemRepository(AppDbContext context,ICartItemRepository cartItemRepository,IProductRepository productRepository)
        {
            _context = context;
            _cartItemRepository = cartItemRepository;
            _productRepository = productRepository;
        }
        public void AddProductsCartItem(ProductsCartItems productsCartItems)
        {
           _context.ProductsCartItems.Add(productsCartItems);
           _context.SaveChanges();
        }
        public ProductsCartItems GetProductsCartItems(int productId, int cartItemsid)
        {
            return _context.ProductsCartItems.FirstOrDefault(pci => pci.ProductsId == productId && pci.CartItemsId == cartItemsid)!;
        }
        public bool HasProductsCartItem(int productId , int cartItemsid)
        {
            var productsCartItems = GetProductsCartItems(productId,cartItemsid);

            return productsCartItems != null;
        }
        public void UpdateItemQuantity(int productId, int cartItemsid,int newQuantity)
        {
            var productsCartItems = GetProductsCartItems(productId, cartItemsid);
            productsCartItems.ItemQuantity += newQuantity;

            _context.SaveChanges();
        }
        public UserOrder GetProductsInShoppingCart(int shoppingCartId)
        {
            var cartItems = _cartItemRepository.GetCartItemByCartId(shoppingCartId);
            var productsCartItems = _context.ProductsCartItems.Where(pci => pci.CartItemsId == cartItems.CartItemId);
            var productsId = productsCartItems.Select(pci => pci.ProductsId).ToList();
            var products = new List<Products>();
            foreach(var Id in productsId)
            {
                var product = _productRepository.GetProductsById(Id);
                products.Add(product);
            }

            var cartItemsId = productsCartItems.Select(pci => pci.CartItemsId).FirstOrDefault();
            var productsCartItemsId = new UserOrder
            {
                CartItemsId = cartItemsId,
                Products = products,
            };
            return productsCartItemsId;
        }
        public void DeleteProductsItems(int productId, int cartItemsid)
        {
            var productsCartItems = GetProductsCartItems(productId, cartItemsid);
            var cartItems = _cartItemRepository.GetCartItemById(cartItemsid);
            cartItems.Quantity--;
            _context.ProductsCartItems.Remove(productsCartItems);
            _context.SaveChanges();
        }
    }
}
