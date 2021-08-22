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
    public class RateService : IRateService
    {
        private readonly HttpClient _client;

        public RateService(HttpClient client)
        {
            _client = client;
        }
        public async Task<SuccessModel> AddRatng(RateDTO rateDTO)
        {
            var content = JsonConvert.SerializeObject(rateDTO);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/Rating/AddRating", bodyContent);

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


        public async Task<SuccessModel> UpdateRatng(RateDTO rateDTO)
        {
            var content = JsonConvert.SerializeObject(rateDTO);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("api/Rating/UpdateRating", bodyContent);

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
            var response = await _client.GetAsync($"api/Rating/GetRating/{Id}");

            if (response.IsSuccessStatusCode)
            {
                var delete = await _client.DeleteAsync($"api/Rating/Delete/{Id}");
                //  return delete;
            }
            else
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(contentTemp);
                throw new Exception(errorModel.ErrorMessage);


            }
        }

        public async Task<RateDTO> GetRatingByCustomer(string customerId)
        {
            var response = await _client.GetAsync($"api/Rating/GetRatingByCustomer/{customerId}");
            var content = await response.Content.ReadAsStringAsync();
            var ratings = JsonConvert.DeserializeObject<RateDTO>(content);
            return ratings;
        }

        public async Task<IEnumerable<RateDTO>> GetRatings()
        {
            var response = await _client.GetAsync($"api/Rating/GetRatings");
            var content = await response.Content.ReadAsStringAsync();
            var ratings = JsonConvert.DeserializeObject<IEnumerable<RateDTO>>(content);
            return ratings;
        }

        public async Task<IEnumerable<RateDTO>> GetRatingsByCustomer(string customerId)
        {
            var response = await _client.GetAsync($"api/Rating/GetRatingsByCustomer/{customerId}");
            var content = await response.Content.ReadAsStringAsync();
            var ratings = JsonConvert.DeserializeObject<IEnumerable<RateDTO>>(content);
            return ratings;
        }

        public async Task<IEnumerable<RateDTO>> GetRatingsBySalon(string salonId)
        {
            var response = await _client.GetAsync($"api/Rating/GetRatingsBySalon/{salonId}");
            var content = await response.Content.ReadAsStringAsync();
            var ratings = JsonConvert.DeserializeObject<IEnumerable<RateDTO>>(content);
            return ratings;
        }

        public async Task<IEnumerable<RateDTO>> GetRatngsByDate(string fromdDateRange, string toDateRange)
        {
            var response = await _client.GetAsync($"api/Rating/GetRatingsByDate/?fromdDateRange={fromdDateRange}&toDateRange={toDateRange}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var ratings = JsonConvert.DeserializeObject<IEnumerable<RateDTO>>(content);
                return ratings;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

      
    }
}
