using Furni_E_Commerce_Service.Models;

namespace Furni_E_Commerce_Service.Repositories.Contracts
{
    public interface ICouponRepository : IAddScoped
    {
        Coupons GetCouponByCoupon(string coupon);
    }
}
