using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Messaging.Models
{
    public class PaymentApprovedIntegrationEvent
    {
        public PaymentApprovedIntegrationEvent(int idProject)
        {
            IdProject = idProject;
        }
        public int IdProject { get; set; }
    }
}