using Furni_E_Commerce_Service.Models;

namespace Furni_E_Commerce_Service.Repositories.Contracts
{
    public interface IPaymentRepository : IAddScoped
    {
        void AddPayment(Payments payment);
        void UpdatePaymentStatus(int orderId, string paymentStatus);
    }
}
