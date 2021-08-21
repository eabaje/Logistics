
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Carrier.Domain.Entities;
using Carrier.FirebaseServer.Interface;
using Carrier.FirebaseServer.Repository;
using Firebase.Database;
using Firebase.Database.Query;
namespace Logistics.Service.API.Repository
{
    public class InsuranceRepository: FirebaseDataStore<Insurance>,IInsuranceService
    {
        private IFireBaseAuthService _authservice;
        private readonly IInsuranceService _InsuranceRepository;

       


       
        public InsuranceRepository( IFireBaseAuthService authService) : base(authService, "Insurance")
        {
           
        }
        public async Task<IEnumerable<Insurance>> GetAllInsurance()
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
        public async Task<bool> AddInsurance(Insurance Insurance)
        {
            try
            {

                bool done = await AddItemAsync(Insurance);
                return done;

            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> UpdateInsurance(Insurance Insurance)
        {
            try
            {

                bool done = await UpdateItemAsync(Insurance.InsuranceId.ToString(), Insurance);

                return done;
            }
            catch
            {
                throw;
            }
        }
        public async Task<Insurance> GetInsuranceById(string id)
        {
            try
            {

                var entity = await GetItemAsync(id);

                return entity;
            }
            catch
            {
                throw;
            }
        }



        public async Task<IEnumerable<Insurance>> GetInsuranceByCarrier(string id)
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

        public async Task<IEnumerable<Insurance>> GetInsuranceByDate(string datecriteria)
        {
            try
            {
                var lst = await GetItemsByCritriaAsync(datecriteria);
                return lst;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> DeleteInsurance(string id)
        {
            try
            {
                bool done = await _InsuranceRepository.DeleteItemAsync(id);

                return done;
            }
            catch
            {
                throw;
            }
        }
    }
}
