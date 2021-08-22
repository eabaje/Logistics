using Logistics.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logistics.AdminUI.Services.Interfaces
{

    public interface IAuthenticationService
    {
        Task<RegisterationResponseDTO> RegisterCustomer(UserRequestDTO userForRegisteration);

        Task<RegisterationResponseDTO> RegisterSalon(UserRequestDTO userForRegisteration);
        Task<AuthenticationResponseDTO> Login(AuthenticationDTO userFromAuthentication);

        Task<ResponseDTO> CheckUser(string email);

        Task Logout();
    }
}
