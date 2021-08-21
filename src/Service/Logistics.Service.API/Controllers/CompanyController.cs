using Carrier.Application.CQRS.CompanyRW.Commands;
using Carrier.Application.CQRS.CompanyRW.Query;
using Carrier.Application.CQRS.LoginRW.Commands;
using Carrier.Application.DTO;
using Logistics.Service.API.Repository.Interfaces;
using Carrier.FirebaseServer.Repository;

using Carrier.Infrastructure.Managers.Implemetations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Logistics.Service.API.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _config;
        private ICompanyService _ICompanyStore;
        private IFireBaseAuthService _authservice;
        //private readonly VehicleService _vehicleService;
        public CompanyController(IConfiguration config,ICompanyService ICompanyStore, IFireBaseAuthService authservice)
        {
           
            _ICompanyStore = ICompanyStore;
            _authservice = authservice;
            _config = config;


        }


       


        public IActionResult AddCompany()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddDriver()
        {
            return View();
        }

       
        



        [HttpGet]
        [Route("Company/{CompanyId}")]
        public async Task<IActionResult> GetCompany(int CompanyId)
        {
            var model = await _mediator.Send(new GetCompanyDetail { CompanyId = CompanyId });
            if (model == null)
                throw new ArgumentNullException(nameof(_mediator));


            return View(model);
        }

        [HttpGet]
        [Route("Company/")]
        public async Task<IActionResult> GetCompanyList()
        {
            var model = await _mediator.Send(new GetCompanyList { });
            if (model == null)
                return NotFound();


            return View(model);
        }

        [HttpPost]
        [Route("Company/AddDriver")]
        public async Task<IActionResult> AddDriver(AddCompany command)
        {
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {

                return View(new ResultMsg { Msg = "Company " + command.CompanyName + " added successfully " });


            }
            else { return NotFound(); }
        }


        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<IActionResult> Register(AddCompany command)
        //{
        //    var result = await _mediator.Send(command);
        //    if (!result.IsSuccess)
        //    {

        //        var plainTextContent = "Load Dispatch is your ideal partner with Load Board Services<b/>" +
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