
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
    public class ShipperRepository: FirebaseDataStore<Shipper>,IShipperService
    {

        private IFireBaseAuthService _authservice;
        private readonly IShipperService _ShipperRepository;


        public ShipperRepository(IFireBaseAuthService authService) : base(authService, "Shippers")
        {

           
        }

        
        public async Task<IEnumerable<Shipper>> GetAllShippers()
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
        public async Task<bool> AddShipper(Shipper Shipper)
        {
            try
            {

                bool done = await AddItemAsync(Shipper);
                return done;

            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> UpdateShipper(Shipper Shipper)
        {
            try
            {

                bool done = await UpdateItemAsync(Shipper.CompanyId.ToString(), Shipper);

                return done;
            }
            catch
            {
                throw;
            }
        }
        public async Task<Shipper> GetShipperById(string id)
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



        public async Task<IEnumerable<Shipper>> GetShipperByName(string id)
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
        public async Task<bool> DeleteShipper(string id)
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
