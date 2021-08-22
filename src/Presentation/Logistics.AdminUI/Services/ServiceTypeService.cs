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
    public class ServiceTypeService : IServiceTypeService
    {
        private readonly HttpClient _client;

        public ServiceTypeService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<ServiceTypeDTO>> GetServiceTypeByDate(string fromdDateRange, string toDateRange)
        {
            var response = await _client.GetAsync($"api/ServiceType/GetServiceTypesByDate/?fromdDateRange={fromdDateRange}&toDateRange={toDateRange}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var services = JsonConvert.DeserializeObject<IEnumerable<ServiceTypeDTO>>(content);
                return services;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task<ServiceTypeDTO> GetServiceTypeById(string Id)
        {
            var response = await _client.GetAsync($"api/ServiceType/GetServiceTypeById/{Id}");
            var content = await response.Content.ReadAsStringAsync();
            var services = JsonConvert.DeserializeObject<ServiceTypeDTO>(content);
            return services;
        }

        public async Task<IEnumerable<ServiceTypeDTO>> GetServiceTypes()
        {
            var response = await _client.GetAsync($"api/ServiceType/GetServiceTypes");
            var content = await response.Content.ReadAsStringAsync();
            var services = JsonConvert.DeserializeObject<IEnumerable<ServiceTypeDTO>>(content);
            return services;
        }


        public async Task<SuccessModel> AddServiceType(ServiceTypeDTO serviceTypeDTO)
        {
            var content = JsonConvert.SerializeObject(serviceTypeDTO);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/ServiceType/CreateServiceType", bodyContent);

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

       
        public async Task<SuccessModel> UpdateServiceType(ServiceTypeDTO serviceTypeDTO)
        {
            var content = JsonConvert.SerializeObject(serviceTypeDTO);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/ServiceType/UpdateServiceType", bodyContent);

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
            var response = await _client.GetAsync($"api/ServiceType/GetServiceType/{Id}");
            if (response.IsSuccessStatusCode)
            {
                var delete = await _client.DeleteAsync($"api/ServiceType/Delete/{Id}");
              //  return delete;
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
