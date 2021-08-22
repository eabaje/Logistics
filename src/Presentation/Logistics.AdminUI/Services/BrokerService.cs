using Newtonsoft.Json;
using Logistics.Shared.Models;
using Logistics.AdminUI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Salon.Common;

namespace Logistics.AdminUI.Services
{
    public class BrokerService : IBookingService
    {

        private readonly HttpClient _client;

        public BrokerService(HttpClient client)
        {
            _client = client;
        }

        public async Task<BookingDTO> AddBooking(BookingDTO bookingDTO)
        {
            var content = JsonConvert.SerializeObject(bookingDTO);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/Booking/AddBooking", bodyContent);
            if (response.IsSuccessStatusCode)
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<BookingDTO>(contentTemp);
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
        public async Task<SuccessModel> UpdateBooking(BookingDTO bookingDTO)
        {
            var content = JsonConvert.SerializeObject(bookingDTO);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("api/Booking/UpdateBooking", bodyContent);

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
            var response = await _client.GetAsync($"api/Booking/GetBooking/{Id}");

            if (response.IsSuccessStatusCode)
            {
                var delete = await _client.DeleteAsync($"api/Booking/Delete/{Id}");
                //  return delete;
            }
            else
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(contentTemp);
                throw new Exception(errorModel.ErrorMessage);


            }

        }

        public async Task<BookingDTO> GetBookingById(string Id)
        {
            var response = await _client.GetAsync($"api/Booking/GetBooking/{Id}");
            var content = await response.Content.ReadAsStringAsync();
            var booking = JsonConvert.DeserializeObject<BookingDTO>(content);
            return booking;
        }

        public async Task<IEnumerable<BookingDTO>> GetBookings()
        {
            var response = await _client.GetAsync($"api/Booking/GetBookings");
            var content = await response.Content.ReadAsStringAsync();
            var bookings = JsonConvert.DeserializeObject<IEnumerable<BookingDTO>>(content);
            return bookings;
        }

        public async Task<IEnumerable<BookingDTO>> GetBookingsByDate(string fromdDateRange, string toDateRange)
        {
            var response = await _client.GetAsync($"api/Booking/GetBookingsByDate/?fromdDateRange={fromdDateRange}&toDateRange={toDateRange}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var bookings = JsonConvert.DeserializeObject<IEnumerable<BookingDTO>>(content);
                return bookings;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public  async Task<SuccessModel> UpdateBookingStatus(string BookId, BookStatus bookingDTO)
        {
            var response = await _client.GetAsync($"api/Booking/GetBooking/{BookId}");

           


        string json = @"[ { 'BookId': '" + BookId + "', 'BookStatus': '" + bookingDTO + "'     } ]";




        int i = (int)bookingDTO;
            if (response.IsSuccessStatusCode)
            {
                var content = JsonConvert.SerializeObject(json);
                var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
                var response1 = await _client.PostAsync("api/Booking/UpdateBookingStatus/", bodyContent);

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
