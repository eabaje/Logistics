using Logistics.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logistics.AdminUI.Services.Interfaces
{
    public interface IVehicleService
    {

        public Task<IEnumerable<VehicleDTO>> GetVehicles();
        public Task<VehicleDTO> GetVehicleById(string Id);

        public Task<IEnumerable<VehicleDTO>> GetVehiclesByCarrier(string carrierId);
        public Task<VehicleDTO> GetVehicleByCarrier(string carrierId);
        public Task<IEnumerable<VehicleDTO>> GetVehiclesByDate(string fromdDateRange, string toDateRange);

        public Task<SuccessModel> AddVehicle(VehicleDTO bookingDTO);

        public Task<SuccessModel> UpdateVehicle(VehicleDTO bookingDTO);

       

        public Task Delete(string Id);
    }
}
