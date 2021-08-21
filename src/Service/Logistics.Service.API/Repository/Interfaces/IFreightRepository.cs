using System;

using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Logistics.Service.API.Entities;

namespace Logistics.Service.API.Repository.Interfaces
{
    public interface IFreightRepository : IDataStore<Carrier>
    {

        Task<IEnumerable<Carrier>> GetFreightCarrierByDate(DateTime fromDate, DateTime ToDate, string carrierId);


    }
}
