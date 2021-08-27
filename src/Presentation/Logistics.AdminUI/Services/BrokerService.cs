using Newtonsoft.Json;
using Logistics.Shared.Models;
using Logistics.AdminUI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Logistics.AdminUI.Services
{
    public class BrokerService : IBrokerService
    {

        private readonly HttpClient _client;

        public BrokerService(HttpClient client)
        {
            _client = client;
        }

        public async Task<BrokerDTO> AddBroker(BrokerDTO BrokerDTO)
        {
            var content = JsonConvert.SerializeObject(BrokerDTO);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/Broker/AddBroker", bodyContent);
            if (response.IsSuccessStatusCode)
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<BrokerDTO>(contentTemp);
                return result;
            }
            else
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(contentTemp);
                throw new Exception(errorModel.ErrorMessage);
            }
            //if (response.IsSuccessStatusCode)
            //{
               
            //    return new SuccessModel { SuccessMessage = "Success" };
            //}
            //else
            //{
            //    //var contentTemp = await response.Content.ReadAsStringAsync();
            //    //var errorModel = JsonConvert.DeserializeObject<ErrorModel>(contentTemp);
            //    return new SuccessModel { SuccessMessage = "Failed" };
            //}
        }
        public async Task<SuccessModel> UpdateBroker(BrokerDTO BrokerDTO)
        {
            var content = JsonConvert.SerializeObject(BrokerDTO);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("api/Broker/UpdateBroker", bodyContent);

            if (response.IsSuccessStatusCode)
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<SuccessModel>(contentTemp);
                
                return result;
            }
            else
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(contentTemp);
                throw new Exception(errorModel.ErrorMessage);
            }
        }
        public async Task Delete(string Id)
        {
            var response = await _client.GetAsync($"api/Broker/GetBroker/{Id}");

            if (response.IsSuccessStatusCode)
            {
                var delete = await _client.DeleteAsync($"api/Broker/Delete/{Id}");
                //  return delete;
            }
            else
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(contentTemp);
                throw new Exception(errorModel.ErrorMessage);


            }

        }

        public async Task<BrokerDTO> GetBrokerById(string Id)
        {
            var response = await _client.GetAsync($"api/Broker/GetBroker/{Id}");
            var content = await response.Content.ReadAsStringAsync();
            var Broker = JsonConvert.DeserializeObject<BrokerDTO>(content);
            return Broker;
        }

        public async Task<IEnumerable<BrokerDTO>> GetBrokers()
        {
            var response = await _client.GetAsync($"api/Broker/GetBrokers");
            var content = await response.Content.ReadAsStringAsync();
            var Brokers = JsonConvert.DeserializeObject<IEnumerable<BrokerDTO>>(content);
            return Brokers;
        }

        public async Task<IEnumerable<BrokerDTO>> GetBrokersByDate(string fromdDateRange, string toDateRange)
        {
            var response = await _client.GetAsync($"api/Broker/GetBrokersByDate/?fromdDateRange={fromdDateRange}&toDateRange={toDateRange}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var Brokers = JsonConvert.DeserializeObject<IEnumerable<BrokerDTO>>(content);
                return Brokers;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public  async Task<SuccessModel> UpdateBrokerStatus(string BrokerId, BrokerDTO BrokerDTO)
        {
            var response = await _client.GetAsync($"api/Broker/GetBroker/{BrokerId}");

           


        string json = @"[ { 'BrokerId': '" +BrokerId + "', 'BrokerStatus': '" + BrokerDTO + "'     } ]";




        //int i = (int)BrokerDTO;
            if (response.IsSuccessStatusCode)
            {
                var content = JsonConvert.SerializeObject(json);
                var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
                var response1 = await _client.PostAsync("api/Broker/UpdateBrokerStatus/", bodyContent);

                var contentTemp = await response1.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<SuccessModel>(contentTemp);
                return result;
                
            }
            else
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(contentTemp);
                throw new Exception(errorModel.ErrorMessage);


            }
        }

      
    }
}
