using System.Numerics;

namespace Furni_E_Commerce_Service.ViewModels
{
    public class OrderShippingViewModel
    {
        public int OrderId { get; set; }
        public string Address { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShippingStatus { get; set; }
        public int TotalAmount { get; set; }
        public double TotalPrice { get; set; }
        public int RemainingDays { get; set; }
        
    }
}
