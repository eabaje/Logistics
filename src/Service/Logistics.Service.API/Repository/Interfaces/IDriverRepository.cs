using System;

using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Logistics.Service.API.Entities;

namespace Logistics.Service.API.Repository.Interfaces
{
    public interface IDriverRepository /*: IDataStore<VehicleDriver>*/
    {

        Task<IEnumerable<VehicleDriver>> GetDriverByName(string DriverName);
        Task<IEnumerable<VehicleDriver>> GetDriverByCarrier(string CompanyId);
        Task<IEnumerable<VehicleDriver>> GetAllDrivers();
        Task<bool> AddDriver(VehicleDriver item);
        Task<bool> UpdateDriver(VehicleDriver item);
        Task<VehicleDriver> GetDriverById(string id);
        Task<bool> DeleteDriver(string id);
    }
}
