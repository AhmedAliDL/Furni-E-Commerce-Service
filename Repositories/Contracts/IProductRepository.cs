using Furni_E_Commerce_Service.Models;

namespace Furni_E_Commerce_Service.Repositories.Contracts
{
    public interface IProductRepository : IAddScoped
    {
        List<Products> GetAllProducts();
        Products GetProductsById(int id);
        void RemoveStockQuantity(Products product, int newStockQuantity);
        void AddStockQuantity(Products product, int newStockQuantity);
    }
}
