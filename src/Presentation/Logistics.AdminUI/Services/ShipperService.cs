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
    public class ShipperService : IShipperService
    {
        private readonly HttpClient _client;
        public ShipperService(HttpClient client)
        {
            _client = client;
        }
        public async Task<ShipperDTO> GetShipperBySalonServiceType(string ServiceTypeId, string salonId)
        {
            var response = await _client.GetAsync($"api/Shipper/GetShipperByServiceType/?ServiceTypeId={ServiceTypeId}&SalonId={salonId}");
            var content = await response.Content.ReadAsStringAsync();
            var services = JsonConvert.DeserializeObject<ShipperDTO>(content);
            return services;
        }

        public Task<ShipperDTO> GetShipperBySalonServiceType(string SerrviceTypeId)
        {
            throw new NotImplementedException();
        }

        public async Task<ShipperDTO> GetShipperByServiceType(string ServiceTypeId, string salonId)
        {
            var response = await _client.GetAsync($"api/Shipper/GetShipperByServiceType/?ServiceTypeId={ServiceTypeId}&SalonId={salonId}");
            var content = await response.Content.ReadAsStringAsync();
            var services = JsonConvert.DeserializeObject<ShipperDTO>(content);
            return services;
        }

        //public Task<IEnumerable<ShipperDTO>> GetShippers()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<ShipperDTO>> GetShippersByServiceType()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
