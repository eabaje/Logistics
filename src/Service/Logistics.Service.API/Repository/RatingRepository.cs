
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
    public class RatingRepository: IRatingRepository
    {

        private readonly LogisticsDbContext _context;

        public RatingRepository(LogisticsDbContext context)
        {

            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> AddItemAsync(Rating item)
        {
            _context
                            .Ratings
                            .Add(item);

            /* return*/
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var entity = _context
                            .Ratings
                            .FirstOrDefault(t => t.RatingId == Guid.Parse(id));

            _context.Ratings.Remove(entity);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Rating> GetItemAsync(string id)
        {
            var Rating = new Rating();

            return Rating =
                             await _context
                            .Ratings
                            .Where(p => p.RatingId == Guid.Parse(id))
                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Rating>> GetItemsAsync()
        {
            List<Rating> RatingList = new List<Rating>();

            return RatingList =
                             await _context
                            .Ratings
                            .ToListAsync();
        }

        public async Task<IEnumerable<Rating>> GetItemsByCritriaAsync(Func<Rating, bool> query)
        {
            List<Rating> RatingList = new List<Rating>();

            RatingList =
                            await _context
                           .Ratings
                           .ToListAsync();


            return RatingList.Where(query);
        }

        public Task<IEnumerable<Rating>> GetRatingByCompany(string CompanyId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Rating>> GetRatingHistory(DateTime fromDate, DateTime ToDate, string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateItemAsync(Rating item)
        {
            _context
                        .Ratings
                        .Update(item);

            /* return*/
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
