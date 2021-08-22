using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using Logistics.Service.API.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Logistics.Shared.Models;
using AutoMapper;
using Logistics.Service.API.Entities;
using System.Net;
using Microsoft.Extensions.Logging;

namespace Logistics.Repository.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly ILogger<CompanyController> _logger;
        private ICompanyRepository _ICompanyStore;
     
        //private readonly VehicleRepository _vehicleRepository;
        public CompanyController(IConfiguration config,ICompanyRepository ICompanyStore, ILogger<CompanyController> logger, IMapper mapper)
        {
           
            _ICompanyStore = ICompanyStore;
            _mapper = mapper;
            _config = config;

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


       


       
        



        [HttpGet]
        [Route("Company/{CompanyId}")]
        public async Task<IActionResult> GetCompany(string CompanyId)
        {
            try
            {
                var entity = await _ICompanyStore.GetItemAsync(CompanyId);

                if (entity == null)
                {
                    return NotFound();
                }

                 return Ok(entity); 
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
          
        }

        [HttpGet]
        [Route("Company/")]
        public async Task<IActionResult> GetCompanyList()
        {
            try
            {
                var entity = await _ICompanyStore.GetItemsAsync();

                if (entity == null)
                {
                    return NotFound();
                }

                return Ok(entity);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
       // [Route("Company/AddDriver")]
        public async Task<IActionResult> AddCompanyProfile(CompanyDTO company)
        {
            try
            {
                var entity = await _ICompanyStore.AddItemAsync(_mapper.Map<Company>(company));

               

                return Ok(entity);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPut]
        // [Route("Company/AddDriver")]
        public async Task<IActionResult> UpdateCompanyProfile(CompanyDTO company)
        {
            try
            {
                var entity = await _ICompanyStore.UpdateItemAsync(_mapper.Map<Company>(company));



                return Ok(entity);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }


        [HttpDelete("{id}")]

        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
              

                return Ok(await _ICompanyStore.DeleteItemAsync(id));

            }
            catch (Exception exc)
            {
                _logger.LogError($"Error: {exc}");
                // transaction.Rollback();
                return NotFound();
            }
        }
        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<IActionResult> Register(AddCompany command)
        //{
        //    var result = await _mediator.Send(command);
        //    if (!result.IsSuccess)
        //    {

        //        var plainTextContent = "Load Dispatch is your ideal partner with Load Board Repositorys<b/>" +
        //      string.Format("Your  login password: New Password: <b>{0}</b>", pwd);
        //        var htmlContent = "<strong>" + plainTextContent + "</strong>";

        //        AccountViewModel Acc = new AccountViewModel { UserName = command.Email, Password = pwd, Message = "", Name = entityUsers.FirstName + " " + entityUsers.LastName };

        //        var msg = _emailClientSender.SendTemplateEmail("", command.Email, entityUsers.FirstName + " " + entityUsers.LastName, "Welcome to Load Dispatch", Acc, "");
        //        return RedirectToAction("Profile", "Account", new { uid = authlink.link.User.LocalId });


        //    }

        //    return Ok();
        //}


    }


}