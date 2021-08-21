
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
    public class JourneyRepository: FirebaseDataStore<Journey>,IJourneyService
    {

        private IFireBaseAuthService _authservice;
        private readonly IJourneyService _JourneyRepository;

        public JourneyRepository(IFireBaseAuthService authService) : base(authService, "Journeys")
        {
         
        }

     
     
        public async Task<IEnumerable<Journey>> GetAllJourneys()
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
        public async Task<bool> AddJourney(Journey Journey)
        {
            try
            {

                bool done = await AddItemAsync(Journey);
                return done;

            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> UpdateJourney(Journey Journey)
        {
            try
            {

                bool done = await UpdateItemAsync(Journey.Id.ToString(), Journey);

                return done;
            }
            catch
            {
                throw;
            }
        }
        public async Task<Journey> GetJourneyById(string id)
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



        public async Task<IEnumerable<Journey>> GetJourneyByCarrier(string id)
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
        public async Task<IEnumerable<Journey>> GetJourneyHistory(string id)
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
        
        public async Task<bool> DeleteJourney(string id)
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
