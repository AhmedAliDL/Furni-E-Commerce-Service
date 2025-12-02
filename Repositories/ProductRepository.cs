using Furni_E_Commerce_Service.Context;
using Furni_E_Commerce_Service.Models;
using Furni_E_Commerce_Service.Repositories.Contracts;
using Microsoft.EntityFrameworkCore.Storage;

namespace Furni_E_Commerce_Service.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Products> GetAllProducts()
        {
            return _context.Products.ToList();
        }
        public Products GetProductsById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.ProductId == id)!;
        }
        public void RemoveStockQuantity(Products product,int newStockQuantity)
        {
            product.StockQuantity -= newStockQuantity;
            if(product.StockQuantity == 0) product.IsActive = false;
            _context.SaveChanges();

        }
        public void AddStockQuantity(Products product,int newStockQuantity)
        {
            product.StockQuantity += newStockQuantity;
            _context.SaveChanges();

        }
    }
}
