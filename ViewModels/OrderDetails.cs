namespace Furni_E_Commerce_Service.ViewModels
{
    public class OrderDetails
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public double ProductPrice { get; set; }
        public double ProductQuantity { get; set; }
        public string ShippingStatus { get; set; }

    }
}
