

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
    public class ConsignmentRepository: IConsignmentRepository
    {


        private readonly LogisticsDbContext _context;

        public ConsignmentRepository(LogisticsDbContext context)
        {

            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Consignment>> GetAllConsignments()
        {
            try
            {

                List<Consignment> ConsignmentList = new List<Consignment>();

                return ConsignmentList =
                                 await _context
                                .Consignments
                                .ToListAsync();

            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> AddConsignment(Consignment Consignment)
        {
            try
            {

                _context
                            .Consignments
                            .Add(Consignment);

                /* return*/
                return await _context.SaveChangesAsync() > 0;

            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> UpdateConsignment(Consignment Consignment)
        {
            try
            {

                _context
                        .Consignments
                         .Update(Consignment);

                /* return*/
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                throw;
            }
        }
        public async Task<Consignment> GetConsignmentById(string id)
        {
            try
            {

                var Consignment = new Consignment();

                return Consignment =
                                 await _context
                                .Consignments
                                .Where(p => p.LoadId == int.Parse(id))
                                .FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }



        public async Task<IEnumerable<Consignment>> GetConsignmentByCarrier(string id)
        {
            try
            {
                List<Consignment> ConsignmentList = new List<Consignment>();

                return ConsignmentList =
                                 await _context
                                .Consignments
                                .Where(p => p.CompanyId == int.Parse(id))
                                .ToListAsync();
            }
            catch
            {
                throw;
            }
        }

      
        public async Task<bool> DeleteConsignment(string id)
        {
            try
            {
                var entity = _context
                              .Consignments
                              .FirstOrDefault(t => t.LoadId == int.Parse(id));

                _context.Consignments.Remove(entity);



                /* return*/
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                throw;
            }
        }

        Task<IEnumerable<Consignment>> IConsignmentRepository.GetConsignmentBy(string carrierId)
        {
            throw new NotImplementedException();
        }

  
        public Task<bool> AddItemAsync(Consignment item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Consignment item)
        {
            throw new NotImplementedException();
        }

        public Task<Consignment> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Consignment>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Consignment>> GetItemsByCritriaAsync(string criteria)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Consignment>> GetConsignmentByDate(DateTime fromDate, DateTime ToDate, string consignmentId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Consignment>> GetItemsByCritriaAsync(Func<Consignment, bool> query)
        {
            throw new NotImplementedException();
        }
    }
}
