using Logistics.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logistics.AdminUI.Services.Interfaces
{
    public interface IServiceTypeService
    {

        public Task<IEnumerable<ServiceTypeDTO>> GetServiceTypes();
        public Task<ServiceTypeDTO> GetServiceTypeById(string Id);
        public Task<IEnumerable<ServiceTypeDTO>> GetServiceTypeByDate(string fromdDateRange, string toDateRange);

        public Task<SuccessModel> AddServiceType(ServiceTypeDTO serviceTypeDTO);

        public Task<SuccessModel> UpdateServiceType(ServiceTypeDTO serviceTypeDTO);

        public Task Delete(string Id);
    }
}
