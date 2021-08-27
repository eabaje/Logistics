using Logistics.Infrastructure.Managers.Abstract;
using Logistics.Service.API.Entities;
using Logistics.Service.API.Helper;
using Logistics.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Logistics.Shared.Constants;

namespace Logistics.Service.API.Controllers
{
    public class AccountController : Controller
    {

        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly APISettings _aPISettings;
        private readonly IEmailManager _emailManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager,
             ILogger<AccountController> logger,
            IOptions<APISettings> options, IEmailManager emailManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _aPISettings = options.Value;
            _emailManager = emailManager;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignUpCustomer([FromBody] UserRequestDTO userRequestDTO)
        {
            if (userRequestDTO == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = new AppUser
            {
                UserName = userRequestDTO.Email,
                Email = userRequestDTO.Email,
                FullName = userRequestDTO.FullName, //string.IsNullOrEmpty(userRequestDTO.FullName)?  userRequestDTO.FirstName + " " +userRequestDTO.LastName: userRequestDTO.FullName,
                PhoneNumber = userRequestDTO.PhoneNo,
                EmailConfirmed = true
            };
            ///  userRequestDTO.Password = PasswordUtil.CreateRandomPassword(8);

            var result = await _userManager.CreateAsync(user, userRequestDTO.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new RegisterationResponseDTO
                { Errors = errors, IsRegisterationSuccessful = false });
            }
            var roleResult = await _userManager.AddToRoleAsync(user, SD.Role_Shipper);
            if (!roleResult.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new RegisterationResponseDTO
                { Errors = errors, IsRegisterationSuccessful = false });
            }
            // Send Email

            //string body = string.Empty;
            //string body1 = string.Empty;
            //body = string.Format("Dear {0} <br/><br/> Project-{1} with  Ref:{2} was assigned to you. <br/><br/>Kindly click on the " +
            //" link to view Project information : <a href =\"{3}\" title =\"Project Review\">{4}</a>" +
            //"<br/><br/>Regards <br/><br/> {5}",
            //AssignedName, project, hdPrj, callbackUrl, "Job Start Up Approval", ApprovedByName);


            //  var sent=  await _emailManager.SendGeneralEmailAsync(userRequestDTO.Email, userRequestDTO.FullName, "Welcome to SmarttCutt", "");


            return StatusCode(201);
        }

      
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> SignIn([FromBody] AuthenticationDTO authenticationDTO)
        {
            var result = await _signInManager.PasswordSignInAsync(authenticationDTO.UserName,
                authenticationDTO.Password, false, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(authenticationDTO.UserName);
                if (user == null)
                {
                    return Unauthorized(new AuthenticationResponseDTO
                    {
                        IsAuthSuccessful = false,
                        ErrorMessage = "Invalid Authentication"
                    });
                }

                //everything is valid and we need to login the user

                var signinCredentials = GetSigningCredentials();
                var claims = await GetClaims(user);

                var tokenOptions = new JwtSecurityToken(
                    issuer: _aPISettings.ValidIssuer,
                    audience: _aPISettings.ValidAudience,
                    claims: claims,
                    expires: DateTime.Now.AddDays(30),
                    signingCredentials: signinCredentials);

                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                return Ok(new AuthenticationResponseDTO
                {
                    IsAuthSuccessful = true,
                    Token = token,
                    userDTO = new UserDTO
                    {
                        Name = user.FullName,
                        Id = user.Id,
                        Email = user.Email,
                        PhoneNo = user.PhoneNumber
                    }
                });
            }
            else
            {
                return Unauthorized(new AuthenticationResponseDTO
                {
                    IsAuthSuccessful = false,
                    ErrorMessage = "Invalid Authentication"
                });
            }
        }



        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> CheckUser([FromBody] UserNameDTO userDTO)
        {
            try
            {
                var isUser = await _userManager.FindByEmailAsync(userDTO.Email);
                if (isUser == null)
                {
                    return Unauthorized(new ResponseDTO
                    {

                        ResponseMessage = "User does not exist",
                        IsSuccessful = false
                    });
                }

                return Ok(new ResponseDTO
                {
                    ResponseMessage = "Valid User",
                    IsSuccessful = true
                });

            }
            catch (Exception exc)
            {
                _logger.LogError($"Error: {exc}");
                // transaction.Rollback();
                return Unauthorized(
                    new ResponseDTO
                    {
                        ResponseMessage = exc.Message,
                        IsSuccessful = false
                    });





            }


        }




        private SigningCredentials GetSigningCredentials()
        {
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_aPISettings.SecretKey));
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims(AppUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.Email),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim("Id",user.Id),

            };
            var roles = await _userManager.GetRolesAsync(await _userManager.FindByEmailAsync(user.Email));

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

    }

}
