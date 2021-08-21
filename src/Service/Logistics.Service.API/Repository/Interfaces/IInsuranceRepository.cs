using System;

using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Logistics.Service.API.Entities;

namespace Logistics.Service.API.Repository.Interfaces
{
   public interface IInsuranceRepository : IDataStore<Insurance>
    {

        Task<IEnumerable<Insurance>> GetInsuranceByDate(DateTime fromDate, DateTime ToDate, string companyId);
      

        Task<IEnumerable<Insurance>> GetInsuranceByCarrier(string id);
     
    }
}
