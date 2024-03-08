using DevFreela.Messaging.Models;

namespace DevFreela.Messaging.Services
{
    public interface IPaymentService
    {
        Task<bool> Process(PaymentInfoInputModel paymentInfoInputModel);

    }
}