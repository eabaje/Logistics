

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Carrier.Domain.Entities;
using Carrier.FirebaseServer.Interface;
using Carrier.FirebaseServer.Repository;
using Firebase.Database;
using Firebase.Database.Query;
namespace Logistics.Service.API.Repository
{
    public class PaymentRepository: FirebaseDataStore<Payment>,IPaymentService
    {

        private IFireBaseAuthService _authservice;
        private readonly IPaymentService _PaymentRepository;

                     
        public PaymentRepository(IFireBaseAuthService authService) : base(authService, "Payment")
        {
          
        }

        
        public async Task<IEnumerable<Payment>> GetAllPayment()
        {
            try
            {

                var lst = await GetItemsAsync(true);
                return lst;


            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> AddPayment(Payment Payment)
        {
            try
            {

                bool done = await AddItemAsync(Payment);
                return done;

            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> UpdatePayment(Payment Payment)
        {
            try
            {

                bool done = await UpdateItemAsync(Payment.PaymentId.ToString(), Payment);

                return done;
            }
            catch
            {
                throw;
            }
        }
        public async Task<Payment> GetPaymentById(string id)
        {
            try
            {

                var entity = await GetItemAsync(id);

                return entity;
            }
            catch
            {
                throw;
            }
        }



        public async Task<IEnumerable<Payment>> GetPaymentByCarrier(string id)
        {
            try
            {
                var lst = await GetItemsByCritriaAsync(id);
                return lst;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Payment>> GetPaymentHistory(string id)
        {
            try
            {
                var lst = await GetItemsByCritriaAsync(id);
                return lst;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> DeletePayment(string id)
        {
            try
            {
                bool done = await DeleteItemAsync(id);

                return done;
            }
            catch
            {
                throw;
            }
        }
    }
}
