using Logistics.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logistics.AdminUI.Services.Interfaces
{

    public interface IRateService
    {

        public Task<IEnumerable<RateDTO>> GetRatings();
        public Task<RateDTO> GetRatingByCustomer(string customerId);
        public Task<IEnumerable<RateDTO>> GetRatingsByCustomer(string customerId);

        public Task<IEnumerable<RateDTO>> GetRatingsBySalon(string salonId);

        public Task<IEnumerable<RateDTO>> GetRatngsByDate(string fromdDateRange, string toDateRange);

        public Task<SuccessModel> AddRatng(RateDTO rateDTO);

        public Task<SuccessModel> UpdateRatng(RateDTO rateDTO);

        public Task Delete(string Id);

    }
}
