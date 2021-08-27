using Logistics.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logistics.AdminUI.Services.Interfaces
{
   public interface ICompanyService
    {
        public Task<IEnumerable<CompanyDTO>> GetCompanys();
        public Task<CompanyDTO> GetCompanyById(string Id);

        public Task<IEnumerable<CompanyDTO>> GetCompanyByName(string name);

        public Task<IEnumerable<CompanyDTO>> GetCompanyByCategory(string name);

        public Task<IEnumerable<CompanyDTO>> GetCompanyByLocation(string location);

        public Task<IEnumerable<CompanyDTO>> GetCompanyLocationByServiceType(string servicetype);

        public Task<IEnumerable<CompanyDTO>> GetCompanyByDate(string fromdDateRange, string toDateRange);

        public Task<SuccessModel> AddCompany(CompanyDTO CompanyDTO);

      

        public Task<SuccessModel> UpdateCompany(CompanyDTO CompanyDTO);

        public Task Delete(string Id);
    }
}
