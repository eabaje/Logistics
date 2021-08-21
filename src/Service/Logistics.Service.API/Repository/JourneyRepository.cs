
using Logistics.Service.API.Data;
using Logistics.Service.API.Entities;
using Logistics.Service.API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Service.API.Repository
{
    public class JourneyRepository: IJourneyRepository
    {

        private readonly LogisticsDbContext _context;

        public JourneyRepository(LogisticsDbContext context)
        {

            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public   async Task<bool> AddItemAsync(Journey item)
        {
            _context
                             .Journeys
                             .Add(item);

            /* return*/
            return await _context.SaveChangesAsync() > 0;
        }

        public   async Task<bool> DeleteItemAsync(string id)
        {
            var entity = _context
                           .Journeys
                           .FirstOrDefault(t => t.JourneyId == int.Parse(id));

            _context.Journeys.Remove(entity);

            return await _context.SaveChangesAsync() > 0;
        }

        public   async Task<Journey> GetItemAsync(string id)
        {
            var Journey = new Journey();

            return Journey =
                             await _context
                            .Journeys
                            .Where(p => p.JourneyId == int.Parse(id))
                            .FirstOrDefaultAsync();
        }

        public   async Task<IEnumerable<Journey>> GetItemsAsync()
        {
            List<Journey> JourneyList = new List<Journey>();

            return JourneyList =
                             await _context
                            .Journeys
                            .ToListAsync();
        }

        public   async Task<IEnumerable<Journey>> GetItemsByCritriaAsync(Func<Journey, bool> query)
        {
            List<Journey> JourneyList = new List<Journey>();

            JourneyList =
                            await _context
                           .Journeys
                           .ToListAsync();


            return JourneyList.Where(query);
        }

        public   async Task<IEnumerable<Journey>> GetJourneyHistory(DateTime fromDate, DateTime ToDate, string vehicleId)
        {
            List<Journey> JourneyList = new List<Journey>();

            return JourneyList = (string.IsNullOrEmpty(vehicleId)) ? await _context
                       .Journeys
                       .Where(p => p.StartDate >= fromDate && p.ArrivalDate <= ToDate)
                       .ToListAsync()
                       : await _context
                       .Journeys
                       .Where(p => p.StartDate >= fromDate && p.ArrivalDate <= ToDate && p.VehicleId == int.Parse(vehicleId))
                       .ToListAsync();
        }

        public   async Task<bool> UpdateItemAsync(Journey item)
        {
            _context
                        .Journeys
                        .Update(item);

            /* return*/
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
