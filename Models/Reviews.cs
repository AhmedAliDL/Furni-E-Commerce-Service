namespace Furni_E_Commerce_Service.Models
{
    public class Reviews
    {
        public int ReviewId { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; } = DateTime.Now;

        public User User { get; set; }
        public Products Product { get; set; }

    }

}
