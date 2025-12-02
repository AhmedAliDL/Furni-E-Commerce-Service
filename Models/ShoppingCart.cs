namespace Furni_E_Commerce_Service.Models
{
    public class ShoppingCart
    {
        public int CartId { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public User User { get; set; }
    }

}
