using System;

using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Logistics.Service.API.Entities;

namespace Logistics.Service.API.Repository.Interfaces
{
   public interface IConsignmentRepository : IDataStore<Consignment>
    {

        Task<IEnumerable<Consignment>> GetConsignmentByDate(DateTime fromDate, DateTime ToDate, string consignmentId);

    }
}
