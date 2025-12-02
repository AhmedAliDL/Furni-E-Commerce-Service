namespace Furni_E_Commerce_Service.Models
{
    public class Orders
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public double TotalAmount { get; set; }
        public string OrderStatus { get; set; }
        public string ShippingAddress { get; set; }
        public string PaymentStatus { get; set; }
        public double CouponDiscount { get; set; } = 0d;

        public User User { get; set; }

    }

}
