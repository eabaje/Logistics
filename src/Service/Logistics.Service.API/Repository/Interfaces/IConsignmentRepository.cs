using System;

using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Logistics.Service.API.Entities;

namespace Logistics.Service.API.Repository.Interfaces
{
   public interface IConsignmentRepository : IDataStore<Consignment>
    {

        Task<IEnumerable<Consignment>> GetConsignmentBy(string carrierId);
        Task<bool> AddConsignment(Consignment item);
        Task<bool> UpdateConsignment(Consignment item);
        Task<Consignment> GetConsignmentById(string id);
        Task<IEnumerable<Consignment>> GetAllConsignments();
        
        Task<bool> DeleteConsignment(string id);

    }
}
