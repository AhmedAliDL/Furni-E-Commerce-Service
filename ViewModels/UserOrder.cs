using Furni_E_Commerce_Service.Models;
using System.ComponentModel.DataAnnotations;

namespace Furni_E_Commerce_Service.ViewModels
{
    public class UserOrder
    {
        [MaxLength(80)]
        public string City { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        [MinLength(16)]
        [MaxLength(16)]
        public string? CardNumber { get; set; }
        [Range(1, 12)]
        public int? ExpirationMonth { get; set; }
        [MaxLength(2)]
        public string? ExpirationYear { get; set; }
        [MaxLength(3)]
        public string? CVV { get; set; }
        public int CartItemsId { get; set; }
        public List<Products> Products { get; set; }
        public List<ProductChoosenQuantityViewModel> ChoosenQuantity { get; set; } = new();
        public double TotalPrice { get; set; }
        public double OrderDiscount { get; set; }
    }
}
