using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Core.DTOs;
using DevFreela.Core.Services;

namespace DevFreela.Infrastructure.PaymentServices
{
    public class PaymentService : IPaymentService
    {
        Task<bool> IPaymentService.Process(PaymentInfoDTO paymentInfoDTO)
        {
            throw new NotImplementedException();
        }
    }
}