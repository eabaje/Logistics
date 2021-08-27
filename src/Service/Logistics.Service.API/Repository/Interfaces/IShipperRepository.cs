using System;

using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Logistics.Service.API.Entities;

namespace Logistics.Service.API.Repository.Interfaces
{
    public interface IShipperRepository : IDataStore<Shipper>
    {

      //  Task<IEnumerable<Shipper>> GetShipperByName(string shipperName);
        Task<IEnumerable<Shipper>> GetShipperHistoryByDate(DateTime fromDate, DateTime ToDate, string shipperId);

    }
}
