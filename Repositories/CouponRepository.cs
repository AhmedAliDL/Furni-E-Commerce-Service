using Furni_E_Commerce_Service.Context;
using Furni_E_Commerce_Service.Models;
using Furni_E_Commerce_Service.Repositories.Contracts;

namespace Furni_E_Commerce_Service.Repositories
{
    public class CouponRepository : ICouponRepository
    {
        private readonly AppDbContext _context;

        public CouponRepository(AppDbContext context)
        {
            _context = context;
        }
        public Coupons GetCouponByCoupon(string coupon)
        {
            return _context.Coupons.FirstOrDefault(c => c.CouponCode == coupon)!;

        }
    }
}
