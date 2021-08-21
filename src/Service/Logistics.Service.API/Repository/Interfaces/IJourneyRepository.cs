using System;

using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Logistics.Service.API.Entities;

namespace Logistics.Service.API.Repository.Interfaces
{
    public interface IJourneyRepository : IDataStore<Journey>
    {

        Task<IEnumerable<Journey>> GetJourneyHistory(DateTime fromDate, DateTime ToDate, string carrierId);
     
       

    }
}
