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
        Task<IEnumerable<Vehicle>> GetVehicleHistoryByDate(DateTime fromDate, DateTime ToDate, string vehicleId);
      


     
    }
}
