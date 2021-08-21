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
   public class DriverRepository:  IDriverRepository
    {

        private readonly LogisticsDbContext _context;

        public DriverRepository(LogisticsDbContext context)
        {

            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
       
        public async Task<IEnumerable<VehicleDriver>> GetAllDrivers()
    {
        try
        {

                List<VehicleDriver> VehicleDriverList = new List<VehicleDriver>();

                return VehicleDriverList =
                                 await _context
                                .Drivers
                                .ToListAsync();

            }
            catch
        {
            throw;
        }
    }
    public async Task<bool> AddDriver(VehicleDriver driver)
    {
        try
        {

                _context
                             .Drivers
                             .Add(driver);

                /* return*/
                return await _context.SaveChangesAsync() > 0;



            }
            catch
        {
            throw;
        }
    }
    public async Task<bool> UpdateDriver(VehicleDriver driver)
    {
        try
        {

                _context
                           .Drivers
                           .Update(driver);

                /* return*/
                return await _context.SaveChangesAsync() > 0;
            }
        catch
        {
            throw;
        }
    }
        public async Task<VehicleDriver> GetDriverById(string id)
        {
            try
            {

                var driver = new VehicleDriver();

                return driver =
                                 await _context
                                .Drivers
                                .Where(p => p.DriverId == int.Parse(id))
                                .FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
       


    public async Task<IEnumerable<VehicleDriver>> GetDriverByCarrier(string CompanyId)
    {
        try
        {

                List<VehicleDriver> VehicleDriverList = new List<VehicleDriver>();

                return VehicleDriverList =
                                 await _context
                                .Drivers

               .Where(a => a.CompanyId == int.Parse(CompanyId)).ToListAsync(); 
            }
        catch
        {
            throw;
        }
    }

        public async Task<IEnumerable<VehicleDriver>> GetDriverByName(string name)
        {
            try
            {

                List<VehicleDriver> VehicleDriverList = new List<VehicleDriver>();

                return VehicleDriverList =
                                 await _context
                                .Drivers

               .Where(a => a.DriverName.Contains(name)).ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> DeleteDriver(string id)
    {
        try
        {
                var entity = _context
                            .Drivers
                            .FirstOrDefault(t => t.DriverId == int.Parse(id));

                _context.Drivers.Remove(entity);



                /* return*/
                return await _context.SaveChangesAsync() > 0;
            }
        catch
        {
            throw;
        }
    }
}
}
