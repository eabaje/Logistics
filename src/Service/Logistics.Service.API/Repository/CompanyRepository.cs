using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Carrier.Domain.Entities;
using Firebase.Database;
using Firebase.Database.Query;
using Carrier.FirebaseServer.Repository;
using Carrier.FirebaseServer.Interface;
using System.Linq;

namespace Logistics.Service.API.Repository
{
    public class CompanyRepository : FirebaseDataStore<Company>, ICompanyService
    {

        private IFireBaseAuthService _authservice;
      
        public CompanyRepository(IFireBaseAuthService authService) : base(authService, "Company")
        {
           
        }

      
        public async Task<IEnumerable<Company>> GetAllCompanys()
        {
            try
            {

                var lst = await GetItemsAsync(true);
                return lst;


            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> AddCompany(Company Company)
        {
            try
            {

                bool done = await AddItemAsync(Company);
                return done;

            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> UpdateCompany(Company Company)
        {
            try
            {

                bool done = await UpdateItemAsync(Company.CompanyId.ToString(), Company);

                return done;
            }
            catch
            {
                throw;
            }
        }
        public async Task<Company> GetCompanyById(Guid id)
        {
            try
            {

                var entity = await GetItemsAsync();

                return entity.Where(a => a.CompanyId == id).FirstOrDefault(); ;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Company>> GetCompanyByCategory(string category)
        {
            try
            {

                var entity = await GetItemsAsync();

                return entity.Where(a => a.Category == category).ToList(); ;
            }
            catch
            {
                throw;
            }
        }

        //public async Task<string> GetCompanyByUserId(string id)
        //{
        //    try
        //    {

        //        var entity = await _CompanyRepository.GetItemAsync(id);

        //        return entity;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        public async Task<IEnumerable<Company>> GetCompanyByCarrier(string id)
        {
            try
            {
                var lst = await GetItemsByCritriaAsync(id);
                return lst;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> DeleteCompany(string id)
        {
            try
            {
                bool done = await DeleteItemAsync(id);

                return done;
            }
            catch
            {
                throw;
            }
        }
    }
}
