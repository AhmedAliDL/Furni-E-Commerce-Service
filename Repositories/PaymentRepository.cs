using Furni_E_Commerce_Service.Context;
using Furni_E_Commerce_Service.Models;
using Furni_E_Commerce_Service.Repositories.Contracts;

namespace Furni_E_Commerce_Service.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _context;

        public PaymentRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddPayment(Payments payment)
        {
            _context.Payments.Add(payment);
            _context.SaveChanges();
        }
        public void UpdatePaymentStatus(int orderId , string paymentStatus)
        {
            var payment = _context.Payments.FirstOrDefault(p => p.OrderId == orderId)!;
            payment.PaymentStatus = paymentStatus;
            _context.SaveChanges();
        }
    }
}
