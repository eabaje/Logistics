using Logistics.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logistics.AdminUI.Services.Interfaces
{
   public interface ICompanyService
    {
        public Task<IEnumerable<BeautySalonDTO>> GetBeautySalons();
        public Task<BeautySalonDTO> GetBeautySalonById(string Id);

        public Task<IEnumerable<BeautySalonDTO>> GetBeautySalonByName(string name);

        public Task<IEnumerable<BeautySalonDTO>> GetBeautySalonByLocation(string location);

        public Task<IEnumerable<BeautySalonDTO>> GetBeautySalonLocationByServiceType(string servicetype);

        public Task<IEnumerable<BeautySalonDTO>> GetBeautySalonByDate(string fromdDateRange, string toDateRange);

        public Task<SuccessModel> AddBeautySalon(BeautySalonDTO beautySalonDTO);

        public Task<SuccessModel> AddBeautySalonToServiceType(SalonServiceDTO salonservice);

        public Task<SuccessModel> RemoveBeautySalonFromServiceType(SalonServiceDTO salonservice);

        public Task<SuccessModel> UpdateBeautySalon(BeautySalonDTO beautySalonDTO);

        public Task Delete(string Id);
    }
}
