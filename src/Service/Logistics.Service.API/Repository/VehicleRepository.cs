using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Service.API.Repository
{
    public class VehicleRepository : FirebaseDataStore<Vehicle>, IVehicleService
    {

        private IFireBaseAuthService _authservice;
        

       
        public VehicleRepository( IFireBaseAuthService authService) : base(authService, "Vehicles")
        {
           
        }
        public async Task<IEnumerable<Vehicle>> GetAllVehicles()
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
        public async Task<bool> AddVehicle(Vehicle vehicle)
        {
            try
            {

                bool done = await AddItemAsync(vehicle);
                return done;

            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> UpdateVehicle(Vehicle vehicle)
        {
            try
            {

                bool done = await UpdateItemAsync(vehicle.CarrierId.ToString(), vehicle);

                return done;
            }
            catch
            {
                throw;
            }
        }
        public async Task<Vehicle> GetVehicleById(string id)
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



        public async Task<IEnumerable<Vehicle>> GetVehicleByCarrier(string id)
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
        public async Task<bool> DeleteVehicle(string id)
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
