using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Core.DTOs;

namespace DevFreela.Core.Services
{
    public interface IPaymentService
    {
        Task<bool> ProcessPayment(PaymentInfoDTO paymentInfoDTO);
    }
}