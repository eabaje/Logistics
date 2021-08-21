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
    public class TransactionRepository: ITransactionRepository
    {

      

        private readonly LogisticsDbContext _context;

        public TransactionRepository(LogisticsDbContext context)
        {

            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

       
        public async Task<IEnumerable<Transaction>> GetAllTransactions()
        {
            try
            {
                List<Transaction> TransactionList = new List<Transaction>();

                return TransactionList =
                                 await _context
                                .Transactions
                                .ToListAsync();


              


            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> AddTransaction(Transaction Transaction)
        {
            try
            {

                _context
                            .Transactions
                            .Add(Transaction);

                /* return*/
                return await _context.SaveChangesAsync() > 0;

              

            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> UpdateTransaction(Transaction Transaction)
        {
            try
            {

                _context
                          .Transactions
                          .Update(Transaction);

                /* return*/
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                throw;
            }
        }
        public async Task<Transaction> GetTransactionById(string id)
        {
            try
            {

                var Transaction = new Transaction();

                return Transaction =
                                 await _context
                                .Transactions
                                .Where(p => p.TransactionId == Guid.Parse(id))
                                .FirstOrDefaultAsync();

            }
            catch
            {
                throw;
            }
        }



        //public async Task<IEnumerable<Transaction>> GetTransactionByCarrier(string id)
        //{
        //    try
        //    {
        //        var lst = await _TransactionRepository.GetItemsByCritriaAsync(id);
        //        return lst;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}


        public async Task<IEnumerable<Transaction>> GetTransactionByDate(DateTime fromDate, DateTime ToDate, string customerId)
        {
            try
            {
                List<Transaction> TransactionList = new List<Transaction>();

                return TransactionList = (string.IsNullOrEmpty(customerId)) ? await _context
                           .Transactions
                           .Where(p => p.TransactionDate >= fromDate && p.TransactionDate <= ToDate)
                           .ToListAsync()
                           : await _context
                           .Transactions
                           .Where(p => p.TransactionDate >= fromDate && p.TransactionDate <= ToDate && p.UserId == customerId)
                           .ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> DeleteTransaction(string id)
        {
            try
            {
                var entity = _context
                            .Transactions
                            .FirstOrDefault(t => t.TransactionId == Guid.Parse(id));

                _context.Transactions.Remove(entity);



                /* return*/
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                throw;
            }
        }

        public Task<IEnumerable<Transaction>> GetTransactionByDate(string TransDate)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddItemAsync(Transaction item)
        {
            _context
                           .Transactions
                           .Add(item);

            /* return*/
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateItemAsync(Transaction item)
        {
            _context
                         .Transactions
                         .Update(item);

            /* return*/
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Transaction> GetItemAsync(string id)
        {
            var Transaction = new Transaction();

            return Transaction =
                             await _context
                            .Transactions
                            .Where(p => p.TransactionId == Guid.Parse(id))
                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Transaction>> GetItemsAsync()
        {
            List<Transaction> TransactionList = new List<Transaction>();

            return TransactionList =
                             await _context
                            .Transactions
                            .ToListAsync();
        }

        public Task<IEnumerable<Transaction>> GetItemsByCritriaAsync(string criteria)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var entity = _context
                            .Transactions
                            .FirstOrDefault(t => t.TransactionId == Guid.Parse(id));

            _context.Transactions.Remove(entity);



            /* return*/
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
