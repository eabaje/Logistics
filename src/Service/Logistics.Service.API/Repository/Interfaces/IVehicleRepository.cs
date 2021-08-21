using System;

using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Logistics.Service.API.Entities;
using Logistics.Service.API.Repository.Interfaces;

namespace Logistics.Service.API.Repository
{
    public interface IVehicleRepository : IDataStore<Vehicle>
    {

        Task<IEnumerable<Vehicle>> GetVehicleByCarrier(string CarrierId);
        Task<IEnumerable<Vehicle>> GetAllVehicles();
       Task<bool> AddVehicle(Vehicle item);
        Task<bool> UpdateVehicle(Vehicle item);
        Task<Vehicle> GetVehicleById(string id);
        Task<bool> DeleteVehicle(string id);
    }
}
