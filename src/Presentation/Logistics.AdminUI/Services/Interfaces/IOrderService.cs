using Logistics.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logistics.AdminUI.Services.Interfaces
{
    public interface IOrderService
    {

        public Task<OrderDTO> PaymentSuccessful(OrderDTO model);
    }
}
