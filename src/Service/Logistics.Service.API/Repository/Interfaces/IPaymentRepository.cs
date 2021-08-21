using System;

using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Logistics.Service.API.Entities;

namespace Logistics.Service.API.Repository.Interfaces
{
   public  interface IPaymentRepository : IDataStore<Payment>
    {

        Task<IEnumerable<Payment>> GetPaymentHistory(DateTime fromDate, DateTime ToDate, string paymentRef);
       

    }
}
