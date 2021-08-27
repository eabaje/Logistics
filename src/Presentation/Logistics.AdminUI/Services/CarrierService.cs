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
    public class CarrierService : ICarrierService
    {

        private readonly HttpClient _client;
        public CarrierService(HttpClient client)
        {
            _client = client;
        }
        public  async Task<SuccessModel> AddCarrier(CarrierDTO CarrierDTO)
        {
            var content = JsonConvert.SerializeObject(CarrierDTO);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/Carrier/AddCarrier", bodyContent);

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

        public  async Task<SuccessModel> UpdateCarrier(CarrierDTO CarrierDTO)
        {
            var content = JsonConvert.SerializeObject(CarrierDTO);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("api/Carrier/UpdateCarrier", bodyContent);

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

        public  async Task Delete(string Id)
        {
            var response = await _client.GetAsync($"api/Carrier/GetCarrier/{Id}");

            if (response.IsSuccessStatusCode)
            {
                var delete = await _client.DeleteAsync($"api/Carrier/Delete/{Id}");
                //  return delete;
            }
            else
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(contentTemp);
                throw new Exception(errorModel.ErrorMessage);


            }
        }

        public  async Task<IEnumerable<CarrierDTO>> GetCarriers()
        {
            var response = await _client.GetAsync($"api/Carrier/GetCarriers");
            var content = await response.Content.ReadAsStringAsync();
            var salons = JsonConvert.DeserializeObject<IEnumerable<CarrierDTO>>(content);
            return salons;
        }

        public  async Task<IEnumerable<CarrierDTO>> GetCarrierByDate(string fromdDateRange, string toDateRange)
        {
            var response = await _client.GetAsync($"api/Carrier/GetCarriersByDate/?fromdDateRange={fromdDateRange}&toDateRange={toDateRange}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var salons = JsonConvert.DeserializeObject<IEnumerable<CarrierDTO>>(content);
                return salons;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public  async Task<CarrierDTO> GetCarrierById(string Id)
        {
            var response = await _client.GetAsync($"api/Carrier/GetCarrierById/{Id}");
            var content = await response.Content.ReadAsStringAsync();
            var salons = JsonConvert.DeserializeObject<CarrierDTO>(content);
            return salons;
        }

        public  async Task<IEnumerable<CarrierDTO>> GetCarrierByLocation(string location)
        {
            var response = await _client.GetAsync($"api/Carrier/GetCarriersByLocation/{location}");
            var content = await response.Content.ReadAsStringAsync();
            var salons = JsonConvert.DeserializeObject<IEnumerable<CarrierDTO>>(content);
            return salons;
        }

        public async Task<IEnumerable<CarrierDTO>> GetCarrierByName(string name)
        {
            var response = await _client.GetAsync($"api/Carrier/GetCarriersByName/{name}");
            var content = await response.Content.ReadAsStringAsync();
            var salons = JsonConvert.DeserializeObject<IEnumerable<CarrierDTO>>(content);
            return salons;
        }

        public async Task<IEnumerable<CarrierDTO>> GetCarrierLocationByServiceType(string servicetype)
        {
            var response = await _client.GetAsync($"api/Carrier/GetCarrierLocationByServiceType/{servicetype}");
            var content = await response.Content.ReadAsStringAsync();
            var salons = JsonConvert.DeserializeObject<IEnumerable<CarrierDTO>>(content);
            return salons;
        }

        public async Task<SuccessModel> AddCarrierToServiceType(CarrierDTO Carriere)
        {




            var content = JsonConvert.SerializeObject(Carriere);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/Carrier/AddCarrierToServiceType", bodyContent);

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

        public async Task<SuccessModel> RemoveCarrierFromServiceType(CarrierDTO Carriere)
        {
            var content = JsonConvert.SerializeObject(Carriere);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/Carrier/RemoveCarrierFromServiceType", bodyContent);

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



        public async Task<SuccessModel> UpdateCarrierFromServiceType(CarrierDTO Carriere)
        {
            var content = JsonConvert.SerializeObject(Carriere);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("api/Carrier/UpdateCarrierFromServiceType", bodyContent);

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
    }
}
