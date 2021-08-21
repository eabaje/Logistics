using System;

using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Logistics.Service.API.Entities;

namespace Logistics.Service.API.Repository.Interfaces
{
   public  interface IPaymentRepository : IDataStore<Payment>
    {

        Task<IEnumerable<Payment>> GetPaymentHistory(string PayDate);
        Task<bool> AddPayment(Payment item);
        Task<bool> UpdatePayment(Payment item);
        Task<Payment> GetPaymentById(string id);
        Task<IEnumerable<Payment>> GetAllPayment();
        Task<IEnumerable<Payment>> GetPaymentByCarrier(string criteria);
        Task<bool> DeletePayment(string id);

    }
}
