

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

      
     
      

  
        public async Task<bool> AddItemAsync(Consignment item)
        {
            _context
                           .Consignments
                           .Add(item);

            /* return*/
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateItemAsync(Consignment item)
        {
            _context
                       .Consignments
                        .Update(item);

            /* return*/
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Consignment> GetItemAsync(string id)
        {
            var Consignment = new Consignment();

            return Consignment =
                             await _context
                            .Consignments
                            .Where(p => p.LoadId == int.Parse(id))
                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Consignment>> GetItemsAsync()
        {
            List<Consignment> ConsignmentList = new List<Consignment>();

            return ConsignmentList =
                             await _context
                            .Consignments
                            .ToListAsync();
        }

        public Task<IEnumerable<Consignment>> GetItemsByCritriaAsync(string criteria)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var entity = _context
                             .Consignments
                             .FirstOrDefault(t => t.LoadId == int.Parse(id));

            _context.Consignments.Remove(entity);



            /* return*/
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Consignment>> GetConsignmentByDate(DateTime fromDate, DateTime ToDate, string consignmentId)
        {
            List<Consignment> ConsignmentList = new List<Consignment>();

            return ConsignmentList = (string.IsNullOrEmpty(consignmentId)) ? await _context
                       .Consignments
                       .Where(p => p.CreatedOn >= fromDate && p.CreatedOn <= ToDate)
                       .ToListAsync()
                       : await _context
                       .Consignments
                       .Where(p => p.CreatedOn >= fromDate && p.CreatedOn <= ToDate && p.LoadId == int.Parse(consignmentId))
                       .ToListAsync();
        }

        public async Task<IEnumerable<Consignment>> GetItemsByCritriaAsync(Func<Consignment, bool> query)
        {
            List<Consignment> ConsignmentList = new List<Consignment>();

            ConsignmentList =
                            await _context
                           .Consignments
                           .ToListAsync();


            return ConsignmentList.Where(query);
        }
    }
}
