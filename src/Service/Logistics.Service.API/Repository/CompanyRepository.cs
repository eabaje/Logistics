using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using System.Linq;
using Logistics.Service.API.Repository.Interfaces;
using Logistics.Service.API.Data;
using Logistics.Service.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Logistics.Service.API.Repository
{
    public class CompanyRepository : ICompanyRepository
    {

        private readonly LogisticsDbContext _context;

        public CompanyRepository(LogisticsDbContext context)
        {

            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> AddItemAsync(Company item)
        {
            _context
                         .Companies
                         .Add(item);

            /* return*/
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var entity = _context
                            .Companies
                            .FirstOrDefault(t => t.CompanyId == int.Parse(id));

            _context.Companies.Remove(entity);



            /* return*/
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Company>> GetComapnyHistoryByDate(DateTime fromDate, DateTime ToDate, string companyId)
        {
            List<Company> CompanyList = new List<Company>();

            return CompanyList = (string.IsNullOrEmpty(companyId)) ? await _context
                       .Companies
                       .Where(p => p.CreatedOn >= fromDate && p.CreatedOn <= ToDate)
                       .ToListAsync()
                       : await _context
                       .Companies
                       .Where(p => p.CreatedOn >= fromDate && p.CreatedOn <= ToDate && p.CompanyId == int.Parse(companyId))
                       .ToListAsync();
        }

        public async Task<Company> GetItemAsync(string id)
        {
            var Company = new Company();

            return Company =
                             await _context
                            .Companies
                            .Where(p => p.CompanyId == int.Parse(id))
                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Company>> GetItemsAsync()
        {
            List<Company> CompanyList = new List<Company>();

            return CompanyList =
                             await _context
                            .Companies
                            .ToListAsync();
        }

        public async Task<IEnumerable<Company>> GetItemsByCritriaAsync(Func<Company, bool> query)
        {
            List<Company> CompanyList = new List<Company>();

            CompanyList =
                            await _context
                           .Companies
                           .ToListAsync();


            return CompanyList.Where(query);
        }

        public async Task<bool> UpdateItemAsync(Company item)
        {
            _context
                          .Companies
                          .Update(item);

            /* return*/
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
