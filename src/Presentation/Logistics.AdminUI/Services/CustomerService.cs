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
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _client;

        public CustomerService(HttpClient client)
        {
            _client = client;
        }
        public async Task<SuccessModel> AddCustomer(CustomerDTO customerDTO)
        {
            var content = JsonConvert.SerializeObject(customerDTO);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/Customer/AddCustomer", bodyContent);

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
            var response = await _client.GetAsync($"api/Customer/GetCustomer/{Id}");

            if (response.IsSuccessStatusCode)
            {
                var delete = await _client.DeleteAsync($"api/Customer/Delete/{Id}");
                //  return delete;
            }
            else
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(contentTemp);
                throw new Exception(errorModel.ErrorMessage);


            }
        }

        public async Task<CustomerDTO> GetCustomerById(string Id)
        {
            var response = await _client.GetAsync($"api/Customer/GetCustomer/{Id}");
            var content = await response.Content.ReadAsStringAsync();
            var customer = JsonConvert.DeserializeObject<CustomerDTO>(content);
            return customer;
        }

        public async Task<IEnumerable<CustomerDTO>> GetCustomers()
        {
            var response = await _client.GetAsync($"api/Customer/GetCustomers");
            var content = await response.Content.ReadAsStringAsync();
            var customers = JsonConvert.DeserializeObject<IEnumerable<CustomerDTO>>(content);
            return customers;
        }

        public async Task<IEnumerable<CustomerDTO>> GetCustomersByDate(string fromdDateRange, string toDateRange)
        {
            var response = await _client.GetAsync($"api/Customer/GetCustomersByDate/?fromdDateRange={fromdDateRange}&toDateRange={toDateRange}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var customers = JsonConvert.DeserializeObject<IEnumerable<CustomerDTO>>(content);
                return customers;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task<SuccessModel> UpdateCustomer(CustomerDTO customerDTO)
        {
            var content = JsonConvert.SerializeObject(customerDTO);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("api/Customer/UpdateCustomer", bodyContent);

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
