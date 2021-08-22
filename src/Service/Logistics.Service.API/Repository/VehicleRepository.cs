using Logistics.Service.API.Data;
using Logistics.Service.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Service.API.Repository
{
    public class VehicleRepository : IVehicleRepository
    {


        private readonly LogisticsDbContext _context;

        public VehicleRepository(LogisticsDbContext context)
        {

            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> AddItemAsync(Vehicle item)
        {
            _context
                          .Vehicles
                          .Add(item);

            /* return*/
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var entity = _context
                            .Vehicles
                            .FirstOrDefault(t => t.VehicleId == Guid.Parse(id));

            _context.Vehicles.Remove(entity);



            /* return*/
            return await _context.SaveChangesAsync() > 0;
        }

      

        public async Task<Vehicle> GetItemAsync(string id)
        {
            var Vehicle = new Vehicle();

            return Vehicle =
                             await _context
                            .Vehicles
                            .Where(p => p.VehicleId == Guid.Parse(id))
                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Vehicle>> GetItemsAsync()
        {
            List<Vehicle> VehicleList = new List<Vehicle>();

            return VehicleList =
                             await _context
                            .Vehicles
                            .ToListAsync();
        }

        public async Task<IEnumerable<Vehicle>> GetItemsByCritriaAsync(Func<Vehicle, bool> query)
        {
            List<Vehicle> VehicleList = new List<Vehicle>();

            VehicleList =
                            await _context
                           .Vehicles
                           .ToListAsync();


            return VehicleList.Where(query);
        }

        public Task<IEnumerable<Vehicle>> GetVehicleByCarrier(string CarrierId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Vehicle>> GetVehicleByVehicle(string VehicleId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Vehicle>> GetVehicleHistoryByDate(DateTime fromDate, DateTime ToDate, string vehicleId)
        {
            List<Vehicle> VehicleList = new List<Vehicle>();

            return VehicleList = (string.IsNullOrEmpty(vehicleId)) ? await _context
                       .Vehicles
                       .Where(p => p.CreatedOn >= fromDate && p.CreatedOn <= ToDate)
                       .ToListAsync()
                       : await _context
                       .Vehicles
                       .Where(p => p.CreatedOn >= fromDate && p.CreatedOn <= ToDate && p.VehicleId == Guid.Parse(vehicleId))
                       .ToListAsync();
        }

        public async Task<bool> UpdateItemAsync(Vehicle item)
        {
            _context
                      .Vehicles
                      .Update(item);

            /* return*/
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
