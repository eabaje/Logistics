using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carrier.Domain.Entities;
using Carrier.FirebaseServer.Interface;
using Carrier.FirebaseServer.Repository;
using Firebase.Database;
using Firebase.Database.Query;
namespace Logistics.Service.API.Repository
{
    public class UserRepository:FirebaseDataStore<Users>,IUserService
    {


        private IFireBaseAuthService _authservice ;

        //   private readonly IUserService _UserRepository;

      
        public UserRepository(IFireBaseAuthService authService) :base(authService,"Users")
        {
            //_authservice=authService;
          
          //  _UserRepository = UserRepository;
        }


        public async Task<IEnumerable<Users>> GetAllUsers()
        {
            try
            {

                var lst = await GetItemsAsync();
                return lst;


            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> AddUser(Users User)
        {
            try
            {

                bool done = await AddItemAsync(User);
                return done;

            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> UpdateUser(string id,Users User)
        {
            try
            {

                bool done = await UpdateItemAsync(User.LocalId.ToString(), User);

                return done;
            }
            catch
            {
                throw;
            }
        }
        public async Task<Users> GetUserByUID(string id)
        {
            try
            {

                var entity = await GetItemsAsync();

                return  entity.Where(a => a.LocalId == id).FirstOrDefault(); ;
            }
            catch
            {
                throw;
            }
        }



        public async Task<IEnumerable<Users>> GetUserByCarrier(string id)
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
        public async Task<bool> DeleteUser(string id)
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
