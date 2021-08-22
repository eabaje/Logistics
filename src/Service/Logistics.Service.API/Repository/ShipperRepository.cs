
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
    public class ShipperRepository:IShipperRepository
    {

        private readonly LogisticsDbContext _context;

        public ShipperRepository(LogisticsDbContext context)
        {

            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> AddItemAsync(Shipper item)
        {
            _context
                          .Shippers
                          .Add(item);

            /* return*/
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var entity = _context
                            .Shippers
                            .FirstOrDefault(t => t.ShipperId == Guid.Parse(id));

            _context.Shippers.Remove(entity);



            /* return*/
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Shipper> GetItemAsync(string id)
        {
            var Shipper = new Shipper();

            return Shipper =
                             await _context
                            .Shippers
                            .Where(p => p.ShipperId == Guid.Parse(id))
                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Shipper>> GetItemsAsync()
        {
            List<Shipper> ShipperList = new List<Shipper>();

            return ShipperList =
                             await _context
                            .Shippers
                            .ToListAsync();
        }

        public async Task<IEnumerable<Shipper>> GetItemsByCritriaAsync(Func<Shipper, bool> query)
        {
            List<Shipper> ShipperList = new List<Shipper>();

            ShipperList =
                            await _context
                           .Shippers
                           .ToListAsync();


            return ShipperList.Where(query);
        }

        public async Task<IEnumerable<Shipper>> GetShipperByName(string shipperName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Shipper>> GetShipperHistoryByDate(DateTime fromDate, DateTime ToDate, string shipperId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateItemAsync(Shipper item)
        {
            _context
                      .Shippers
                      .Update(item);

            /* return*/
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
