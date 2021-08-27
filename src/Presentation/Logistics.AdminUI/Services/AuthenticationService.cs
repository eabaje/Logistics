using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using Logistics.Shared.Models;
using Logistics.AdminUI.Services.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
//using System.Text.Json;
using System.Threading.Tasks;
using static Logistics.Shared.Constants;

namespace Logistics.AdminUI.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _client;
        //private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authStateProvider;

        public AuthenticationService(HttpClient client, /*ILocalStorageService localStorage,*/ AuthenticationStateProvider authStateProvider)
        {
            _client = client;
            _authStateProvider = authStateProvider;
            //((AuthStateProvider)_authStateProvider).NotifyUserLogout();
            //_localStorage = localStorage;
        }

        public async Task<ResponseDTO> CheckUser(string email)
        {
            var userDTO = new UserNameDTO
            {
                Email = email
                
            };

           
            var content = JsonConvert.SerializeObject(userDTO);
          
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/account/checkuser", bodyContent);

            var contentTemp = await response.Content.ReadAsStringAsync();
           
            var result = JsonConvert.DeserializeObject<ResponseDTO>(contentTemp);

            if (response.IsSuccessStatusCode)
            {
                await _localStorage.SetItemAsync(SD.error_msg_operation_failed, result.ResponseMessage);
                return new ResponseDTO { IsSuccessful = true };

            }
            else
            {
               
                return result;
            }
        }

        public async Task<AuthenticationResponseDTO> Login(AuthenticationDTO userFromAuthentication)
        {
            var content = JsonConvert.SerializeObject(userFromAuthentication);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/account/signin", bodyContent);
            var contentTemp = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AuthenticationResponseDTO>(contentTemp);

            if (response.IsSuccessStatusCode)
            {
                await _localStorage.SetItemAsync(SD.Local_Token, result.Token);
                await _localStorage.SetItemAsync(SD.Local_UserDetails, result.userDTO);
                ((AuthStateProvider)_authStateProvider).NotifyUserLoggedIn(result.Token);
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);
                return new AuthenticationResponseDTO { IsAuthSuccessful = true };
            }
            else
            {
                return result;
            }
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync(SD.Local_Token);
            await _localStorage.RemoveItemAsync(SD.Local_UserDetails);
            _client.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<RegisterationResponseDTO> RegisterCustomer(UserRequestDTO userForRegisteration)
        {
            var content = JsonConvert.SerializeObject(userForRegisteration);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/account/signupcustomer", bodyContent);
            var contentTemp = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<RegisterationResponseDTO>(contentTemp);

            if (response.IsSuccessStatusCode)
            {

                return new RegisterationResponseDTO { IsRegisterationSuccessful = true };
            }
            else
            {
                return result;
            }
        }





        public async Task<RegisterationResponseDTO> RegisterSalon(UserRequestDTO userForRegisteration)
        {
            var content = JsonConvert.SerializeObject(userForRegisteration);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/account/signupsalon", bodyContent);
            var contentTemp = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<RegisterationResponseDTO>(contentTemp);

            if (response.IsSuccessStatusCode)
            {

                return new RegisterationResponseDTO { IsRegisterationSuccessful = true };
            }
            else
            {
                return result;
            }
        }

    }
   
}

