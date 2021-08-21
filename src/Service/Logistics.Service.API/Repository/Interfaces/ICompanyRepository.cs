using Logistics.Service.API.Entities;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;



namespace Logistics.Service.API.Repository.Interfaces
{
    public interface ICompanyRepository : IDataStore<Company>
    {

          Task<IEnumerable<Company>> GetCompanyByCarrier(string id);
        Task<IEnumerable<Company>> GetCompanyByCategory(string category);
        Task<Company> GetCompanyById(Guid companyId);

    }
}
    

