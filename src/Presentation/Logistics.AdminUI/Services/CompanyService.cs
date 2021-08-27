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
    public class CompanyService : ICompanyService
    {
        private readonly HttpClient _client;

        public CompanyService(HttpClient client)
        {
            _client = client;
        }
        public async Task<SuccessModel> AddCompany(CompanyDTO CompanyDTO)
        {
            var content = JsonConvert.SerializeObject(CompanyDTO);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/Company/AddCompany", bodyContent);

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
            var response = await _client.GetAsync($"api/Company/GetCompany/{Id}");

            if (response.IsSuccessStatusCode)
            {
                var delete = await _client.DeleteAsync($"api/Company/Delete/{Id}");
                //  return delete;
            }
            else
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(contentTemp);
                throw new Exception(errorModel.ErrorMessage);


            }
        }

        public Task<IEnumerable<CompanyDTO>> GetCompanyByCategory(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CompanyDTO>> GetCompanyByDate(string fromdDateRange, string toDateRange)
        {
            throw new NotImplementedException();
        }

        public async Task<CompanyDTO> GetCompanyById(string Id)
        {
            var response = await _client.GetAsync($"api/Company/GetCompany/{Id}");
            var content = await response.Content.ReadAsStringAsync();
            var Company = JsonConvert.DeserializeObject<CompanyDTO>(content);
            return Company;
        }

        public Task<IEnumerable<CompanyDTO>> GetCompanyByLocation(string location)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CompanyDTO>> GetCompanyByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CompanyDTO>> GetCompanyLocationByServiceType(string servicetype)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CompanyDTO>> GetCompanys()
        {
            var response = await _client.GetAsync($"api/Company/GetCompanys");
            var content = await response.Content.ReadAsStringAsync();
            var Companys = JsonConvert.DeserializeObject<IEnumerable<CompanyDTO>>(content);
            return Companys;
        }

        public async Task<IEnumerable<CompanyDTO>> GetCompanysByDate(string fromdDateRange, string toDateRange)
        {
            var response = await _client.GetAsync($"api/Company/GetCompanysByDate/?fromdDateRange={fromdDateRange}&toDateRange={toDateRange}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var Companys = JsonConvert.DeserializeObject<IEnumerable<CompanyDTO>>(content);
                return Companys;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task<SuccessModel> UpdateCompany(CompanyDTO CompanyDTO)
        {
            var content = JsonConvert.SerializeObject(CompanyDTO);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("api/Company/UpdateCompany", bodyContent);

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
