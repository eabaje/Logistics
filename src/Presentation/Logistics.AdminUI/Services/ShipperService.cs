using Newtonsoft.Json;
using Logistics.AdminUI.Services.Interfaces;
using Logistics.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Logistics.AdminUI.Services
{
    public class ShipperService : IPriceListService
    {
        private readonly HttpClient _client;
        public ShipperService(HttpClient client)
        {
            _client = client;
        }
        public async Task<PriceListDTO> GetPriceListBySalonServiceType(string ServiceTypeId, string salonId)
        {
            var response = await _client.GetAsync($"api/PriceList/GetPriceListByServiceType/?ServiceTypeId={ServiceTypeId}&SalonId={salonId}");
            var content = await response.Content.ReadAsStringAsync();
            var services = JsonConvert.DeserializeObject<PriceListDTO>(content);
            return services;
        }

        public Task<PriceListDTO> GetPriceListBySalonServiceType(string SerrviceTypeId)
        {
            throw new NotImplementedException();
        }

        public async Task<PriceListDTO> GetPriceListByServiceType(string ServiceTypeId, string salonId)
        {
            var response = await _client.GetAsync($"api/PriceList/GetPriceListByServiceType/?ServiceTypeId={ServiceTypeId}&SalonId={salonId}");
            var content = await response.Content.ReadAsStringAsync();
            var services = JsonConvert.DeserializeObject<PriceListDTO>(content);
            return services;
        }

        //public Task<IEnumerable<PriceListDTO>> GetPriceLists()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<PriceListDTO>> GetPriceListsByServiceType()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
