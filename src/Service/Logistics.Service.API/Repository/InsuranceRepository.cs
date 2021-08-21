
using Logistics.Service.API.Data;
using Logistics.Service.API.Entities;
using Logistics.Service.API.Repository.Interfaces;
using System;
using System.Collections.Generic;
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

        public Task<bool> AddItemAsync(Insurance item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Insurance>> GetInsuranceByCarrier(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Insurance>> GetInsuranceByDate(string InsureDate)
        {
            throw new NotImplementedException();
        }

        public Task<Insurance> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Insurance>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Insurance>> GetItemsByCritriaAsync(Func<Insurance, bool> query)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Insurance item)
        {
            throw new NotImplementedException();
        }
    }
}
