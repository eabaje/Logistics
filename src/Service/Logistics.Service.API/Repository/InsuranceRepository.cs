
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
    public class InsuranceRepository:IInsuranceRepository
    {






        private readonly LogisticsDbContext _context;

        public InsuranceRepository(LogisticsDbContext context)
        {

            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> AddItemAsync(Insurance item)
        {
            _context
                           .Insurances
                           .Add(item);

            /* return*/
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var entity = _context
                           .Insurances
                           .FirstOrDefault(t => t.InsuranceId == Guid.Parse(id));

            _context.Insurances.Remove(entity);



            /* return*/
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<IEnumerable<Insurance>> GetInsuranceByCarrier(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Insurance>> GetInsuranceByDate(DateTime fromDate, DateTime ToDate, string companyId)
        {
            List<Insurance> InsuranceList = new List<Insurance>();

            return InsuranceList = (string.IsNullOrEmpty(companyId)) ? await _context
                       .Insurances
                       .Where(p => p.CreatedOn >= fromDate && p.CreatedOn <= ToDate)
                       .ToListAsync()
                       : await _context
                       .Insurances
                       .Where(p => p.CreatedOn >= fromDate && p.CreatedOn <= ToDate && p. == companyId)
                       .ToListAsync();
        }

        public async Task<Insurance> GetItemAsync(string id)
        {
            var Insurance = new Insurance();

            return Insurance =
                             await _context
                            .Insurances
                            .Where(p => p.InsuranceId == int.Parse(id))
                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Insurance>> GetItemsAsync()
        {
            List<Insurance> InsuranceList = new List<Insurance>();

            return InsuranceList =
                             await _context
                            .Insurances
                            .ToListAsync();
        }

        public async Task<IEnumerable<Insurance>> GetItemsByCritriaAsync(Func<Insurance, bool> query)
        {
            List<Insurance> InsuranceList = new List<Insurance>();

            InsuranceList =
                            await _context
                           .Insurances
                           .ToListAsync();


            return InsuranceList.Where(query);
        }

        public Task<bool> UpdateItemAsync(Insurance item)
        {
            _context
                         .Insurances
                         .Update(item);

            /* return*/
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
