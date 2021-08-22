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
    public class CarrierService : IBeautySalonService
    {

        private readonly HttpClient _client;
        public CarrierService(HttpClient client)
        {
            _client = client;
        }
        public  async Task<SuccessModel> AddBeautySalon(BeautySalonDTO beautySalonDTO)
        {
            var content = JsonConvert.SerializeObject(beautySalonDTO);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/BeautySalon/AddBeautySalon", bodyContent);

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

        public  async Task<SuccessModel> UpdateBeautySalon(BeautySalonDTO beautySalonDTO)
        {
            var content = JsonConvert.SerializeObject(beautySalonDTO);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("api/BeautySalon/UpdateBeautySalon", bodyContent);

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
            var response = await _client.GetAsync($"api/BeautySalon/GetBeautySalon/{Id}");

            if (response.IsSuccessStatusCode)
            {
                var delete = await _client.DeleteAsync($"api/BeautySalon/Delete/{Id}");
                //  return delete;
            }
            else
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(contentTemp);
                throw new Exception(errorModel.ErrorMessage);


            }
        }

        public  async Task<IEnumerable<BeautySalonDTO>> GetBeautySalons()
        {
            var response = await _client.GetAsync($"api/BeautySalon/GetBeautySalons");
            var content = await response.Content.ReadAsStringAsync();
            var salons = JsonConvert.DeserializeObject<IEnumerable<BeautySalonDTO>>(content);
            return salons;
        }

        public  async Task<IEnumerable<BeautySalonDTO>> GetBeautySalonByDate(string fromdDateRange, string toDateRange)
        {
            var response = await _client.GetAsync($"api/BeautySalon/GetBeautySalonsByDate/?fromdDateRange={fromdDateRange}&toDateRange={toDateRange}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var salons = JsonConvert.DeserializeObject<IEnumerable<BeautySalonDTO>>(content);
                return salons;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public  async Task<BeautySalonDTO> GetBeautySalonById(string Id)
        {
            var response = await _client.GetAsync($"api/BeautySalon/GetBeautySalonById/{Id}");
            var content = await response.Content.ReadAsStringAsync();
            var salons = JsonConvert.DeserializeObject<BeautySalonDTO>(content);
            return salons;
        }

        public  async Task<IEnumerable<BeautySalonDTO>> GetBeautySalonByLocation(string location)
        {
            var response = await _client.GetAsync($"api/BeautySalon/GetBeautySalonsByLocation/{location}");
            var content = await response.Content.ReadAsStringAsync();
            var salons = JsonConvert.DeserializeObject<IEnumerable<BeautySalonDTO>>(content);
            return salons;
        }

        public async Task<IEnumerable<BeautySalonDTO>> GetBeautySalonByName(string name)
        {
            var response = await _client.GetAsync($"api/BeautySalon/GetBeautySalonsByName/{name}");
            var content = await response.Content.ReadAsStringAsync();
            var salons = JsonConvert.DeserializeObject<IEnumerable<BeautySalonDTO>>(content);
            return salons;
        }

        public async Task<IEnumerable<BeautySalonDTO>> GetBeautySalonLocationByServiceType(string servicetype)
        {
            var response = await _client.GetAsync($"api/BeautySalon/GetBeautySalonLocationByServiceType/{servicetype}");
            var content = await response.Content.ReadAsStringAsync();
            var salons = JsonConvert.DeserializeObject<IEnumerable<BeautySalonDTO>>(content);
            return salons;
        }

        public async Task<SuccessModel> AddBeautySalonToServiceType(SalonServiceDTO salonservice)
        {




            var content = JsonConvert.SerializeObject(salonservice);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/BeautySalon/AddBeautySalonToServiceType", bodyContent);

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

        public async Task<SuccessModel> RemoveBeautySalonFromServiceType(SalonServiceDTO salonservice)
        {
            var content = JsonConvert.SerializeObject(salonservice);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/BeautySalon/RemoveBeautySalonFromServiceType", bodyContent);

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



        public async Task<SuccessModel> UpdateBeautySalonFromServiceType(SalonServiceDTO salonservice)
        {
            var content = JsonConvert.SerializeObject(salonservice);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("api/BeautySalon/UpdateBeautySalonFromServiceType", bodyContent);

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
