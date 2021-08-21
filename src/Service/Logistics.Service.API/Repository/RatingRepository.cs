
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
    public class RatingRepository: FirebaseDataStore<Rating>, IRatingService
    {

        private IFireBaseAuthService _authservice;
        private readonly IRatingService _RatingRepository;


        public RatingRepository( IFireBaseAuthService authService) : base(authService, "Ratings")
        {
           
           
        }
        public async Task<IEnumerable<Rating>> GetAllRatings()
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
        public async Task<bool> AddRating(Rating Rating)
        {
            try
            {

                bool done = await AddItemAsync(Rating);
                return done;

            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> UpdateRating(Rating Rating)
        {
            try
            {

                bool done = await UpdateItemAsync(Rating.RatingId.ToString(), Rating);

                return done;
            }
            catch
            {
                throw;
            }
        }
        public async Task<Rating> GetRatingById(string id)
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



        public async Task<IEnumerable<Rating>> GetRatingByCarrier(string id)
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
        public async Task<IEnumerable<Rating>> GetRatingByCompany(string id)
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
        public async Task<bool> DeleteRating(string id)
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
