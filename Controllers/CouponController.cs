using Furni_E_Commerce_Service.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Furni_E_Commerce_Service.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponRepository _couponRepository;

        public CouponController(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
        }

        [HttpPost]
        public IActionResult CheckCoupon([FromForm] string coupon)
        {
            if (string.IsNullOrEmpty(coupon))
            {
                return Json(new { success = false, message = "Invalid coupon" });
            }

            var foundCoupon = _couponRepository.GetCouponByCoupon(coupon);

            if (foundCoupon == null)
            {
                return Json(new { success = false, message = "Coupon not found" });
            }

            return Json(new { success = true, data = new { discountPercentage = foundCoupon.CouponRatio } });
        }
    }
}
