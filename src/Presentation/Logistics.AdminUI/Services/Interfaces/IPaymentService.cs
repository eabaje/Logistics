using Logistics.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logistics.AdminUI.Services.Interfaces
{

    public interface IPaymentService
    {
        public Task<SuccessModel> StripeCheckOut(PaymentDTO model);
    }
}
