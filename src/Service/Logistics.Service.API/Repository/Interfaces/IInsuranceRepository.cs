using System;

using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Logistics.Service.API.Entities;

namespace Logistics.Service.API.Repository.Interfaces
{
   public interface IInsuranceRepository : IDataStore<Insurance>
    {

        Task<IEnumerable<Insurance>> GetInsuranceByDate(string InsureDate);

        Task<IEnumerable<Insurance>> GetAllInsurance();
        Task<IEnumerable<Insurance>> GetInsuranceByCarrier(string id);
        Task<bool> AddInsurance(Insurance item);
        Task<bool> UpdateInsurance(Insurance item);
        Task<Insurance> GetInsuranceById(string id);
        Task<bool> DeleteInsurance(string id);
    }
}
