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
    public class FreightRepository: IFreightRepository
    {


        private readonly LogisticsDbContext _context;

        public FreightRepository(LogisticsDbContext context)
        {

            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


       
      

        public async Task<IEnumerable<Carrier>> GetFreightCarrierByDate(DateTime fromDate, DateTime ToDate, string carrierId)
        {
            List<Carrier> CarrierList = new List<Carrier>();

            return CarrierList = (string.IsNullOrEmpty(carrierId)) ? await _context
                       .Carriers
                       .Where(p => p.CreatedOn >= fromDate && p.CreatedOn <= ToDate)
                       .ToListAsync()
                       : await _context
                       .Carriers
                       .Where(p => p.CreatedOn >= fromDate && p.CreatedOn <= ToDate && p.CompanyId == int.Parse(carrierId))
                       .ToListAsync();
        }

        public async Task<bool> AddItemAsync(Carrier item)
        {
            _context
                          .Carriers
                          .Add(item);

            /* return*/
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateItemAsync(Carrier item)
        {
                          _context
                          .Carriers
                          .Update(item);

            /* return*/
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Entities.Carrier> GetItemAsync(string id)
        {
            var Carrier = new Carrier();

            return Carrier =
                             await _context
                            .Carriers
                            .Where(p => p.CarrierId == Guid.Parse(id))
                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Entities.Carrier>> GetItemsAsync()
        {
            List<Carrier> CarrierList = new List<Carrier>();

            return CarrierList =
                             await _context
                            .Carriers
                            .ToListAsync();
        }

        public async Task<IEnumerable<Carrier>> GetItemsByCritriaAsync(Func<Carrier, bool> query)
        {
            List<Carrier> CarrierList = new List<Carrier>();

            CarrierList =
                            await _context
                           .Carriers
                           .ToListAsync();


            return CarrierList.Where(query);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var entity = _context
                            .Carriers
                            .FirstOrDefault(t => t.CarrierId == Guid.Parse(id));

            _context.Carriers.Remove(entity);



            /* return*/
            return await _context.SaveChangesAsync() > 0;
        }

       
    }
}
