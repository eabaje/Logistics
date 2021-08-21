using System;

using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Logistics.Service.API.Entities;


namespace Logistics.Service.API.Repository.Interfaces
{
    public interface IRatingRepository : IDataStore<Rating>
    {

        Task<IEnumerable<Rating>> GetRatingByCompany(string CompanyId);
        Task<IEnumerable<Rating>> GetRatingHistory(DateTime fromDate, DateTime ToDate, string userId);

    }
}
