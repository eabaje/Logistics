using Logistics.AdminUI.Services.Interfaces;
using Logistics.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logistics.AdminUI.Services
{
    public class VehicleService : IVehicleService
    {
        public Task<SuccessModel> AddVehicle(VehicleDTO bookingDTO)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<VehicleDTO> GetVehicleByCarrier(string carrierId)
        {
            throw new NotImplementedException();
        }

        public Task<VehicleDTO> GetVehicleById(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VehicleDTO>> GetVehicles()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VehicleDTO>> GetVehiclesByCarrier(string carrierId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VehicleDTO>> GetVehiclesByDate(string fromdDateRange, string toDateRange)
        {
            throw new NotImplementedException();
        }

        public Task<SuccessModel> UpdateVehicle(VehicleDTO bookingDTO)
        {
            throw new NotImplementedException();
        }
    }
}
