namespace Furni_E_Commerce_Service.Models
{
    public class Payments
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public double Amount { get; set; }
        public string PaymentStatus {get; set; }

        public Orders Order {  get; set; }
    }

}
