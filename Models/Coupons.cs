using System.ComponentModel.DataAnnotations;

namespace Furni_E_Commerce_Service.Models
{
    public class Coupons
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        [Range(0.1,100)]
        public double CouponRatio { get; set; }
    }
}
