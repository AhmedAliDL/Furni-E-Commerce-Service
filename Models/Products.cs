using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace Furni_E_Commerce_Service.Models
{
    public class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }

        public Categories Category { get; set; }

        public virtual ICollection<ProductsCartItems> ProductsCartItems { get; set; }


    }

}
