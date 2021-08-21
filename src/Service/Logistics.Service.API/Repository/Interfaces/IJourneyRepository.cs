using System;

using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Logistics.Service.API.Entities;

namespace Logistics.Service.API.Repository.Interfaces
{
    public interface IJourneyRepository : IDataStore<Journey>
    {

        Task<IEnumerable<Journey>> GetJourneyHistory(string JourneyDate);
        Task<bool> AddJourney(Journey item);
        Task<bool> UpdateJourney(Journey item);
        Task<Journey> GetJourneyById(string id);
        Task<IEnumerable<Journey>> GetAllJourneys();
        Task<IEnumerable<Journey>> GetJourneyByCarrier(string criteria);
        Task<bool> DeleteJourney(string id);

    }
}
