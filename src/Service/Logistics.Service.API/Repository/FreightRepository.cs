using Logistics.Service.API.Data;
using Logistics.Service.API.Entities;
using Logistics.Service.API.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Service.API.Repository
{
    public class FreightRepository: IFreightRepository
    {


        private readonly LogisticsDbContext _context;

        public FreightRepository(LogisticsDbContext context)
        {

            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


       
        public async Task<IEnumerable<Carrier>> GetAllFreights()
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
        public async Task<bool> AddFreight(FreightCarrier Freight)
        {
            try
            {

                bool done = await AddItemAsync(Freight);
                return done;

            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> UpdateFreight(FreightCarrier Freight)
        {
            try
            {

                bool done = await UpdateItemAsync(Freight.CarrierId.ToString(), Freight);

                return done;
            }
            catch
            {
                throw;
            }
        }
        public async Task<FreightCarrier> GetFreightById(string id)
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



        public async Task<IEnumerable<FreightCarrier>> GetFreightByCarrier(string id)
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

        public async Task<IEnumerable<FreightCarrier>> GetFreightCarrierByDate(string id)
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
        public async Task<bool> DeleteFreight(string id)
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

        public Task<IEnumerable<Carrier>> GetFreightCarrierByDate(DateTime fromDate, DateTime ToDate, string carrierId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddItemAsync(Carrier item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Entities.Carrier item)
        {
            throw new NotImplementedException();
        }

        public Task<Entities.Carrier> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Entities.Carrier>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Entities.Carrier>> GetItemsByCritriaAsync(string criteria)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
