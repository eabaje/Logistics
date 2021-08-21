

using Logistics.Service.API.Data;
using Logistics.Service.API.Entities;
using Logistics.Service.API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Service.API.Repository
{
    public class PaymentRepository: IPaymentRepository
    {

        private readonly LogisticsDbContext _context;

        public PaymentRepository(LogisticsDbContext context)
        {

            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> AddItemAsync(Payment item)
        {
            _context
                            .Payments
                            .Add(item);

            /* return*/
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var entity = _context
                            .Payments
                            .FirstOrDefault(t => t.PaymentId == Guid.Parse(id));

            _context.Payments.Remove(entity);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Payment> GetItemAsync(string id)
        {
            var Payment = new Payment();

            return Payment =
                             await _context
                            .Payments
                            .Where(p => p.PaymentId == Guid.Parse(id))
                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Payment>> GetItemsAsync()
        {
            List<Payment> PaymentList = new List<Payment>();

            return PaymentList =
                             await _context
                            .Payments
                            .ToListAsync();
        }

        public async Task<IEnumerable<Payment>> GetItemsByCritriaAsync(Func<Payment, bool> query)
        {
            List<Payment> PaymentList = new List<Payment>();

            PaymentList =
                            await _context
                           .Payments
                           .ToListAsync();


            return PaymentList.Where(query);
        }

        public async Task<IEnumerable<Payment>> GetPaymentHistory(DateTime fromDate, DateTime ToDate, string paymentRef)
        {
            List<Payment> PaymentList = new List<Payment>();

            return PaymentList = (string.IsNullOrEmpty(paymentRef)) ? await _context
                       .Payments
                       .Where(p => p.PaymentDate >= fromDate && p.PaymentDate <= ToDate)
                       .ToListAsync()
                       : await _context
                       .Payments
                       .Where(p => p.PaymentDate >= fromDate && p.PaymentDate <= ToDate && p.ReferenceId == paymentRef)
                       .ToListAsync();
        }

        public async Task<bool> UpdateItemAsync(Payment item)
        {
            _context
                        .Payments
                        .Update(item);

            /* return*/
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
