using Carrier.Application.CQRS.CompanyRW.Commands;
using Carrier.Application.CQRS.InsuranceRW.Commands;
using Carrier.Application.CQRS.InsuranceRW.Query;
using Carrier.Application.CQRS.LoginRW.Commands;
using Carrier.Application.DTO;
using Carrier.Application.Exceptions;
using Logistics.Service.API.Entities;
using Logistics.Service.API.Repository.Interfaces;
using Carrier.FirebaseServer.Repository;

using Logistics.Service.API.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Logistics.Service.API.Controllers
{
    public class InsuranceController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _config;
        private IUserService _IUserStore;
        private IInsuranceService _insuranceService;
        private IFireBaseAuthService _authservice;

        //private FireBaseAuthService _authservice = new FireBaseAuthService();


        public InsuranceController(IConfiguration config, IUserService IUserStore, IInsuranceService insuranceService, IFireBaseAuthService authservice)
        {
            if (IUserStore == null)
                throw new ArgumentNullException(nameof(IUserStore));
            _IUserStore = IUserStore;
            _insuranceService = insuranceService;
            _authservice = authservice;
            _config = config;


        }

      

        public async Task<IActionResult>  Index()
        {
            var entity = await _insuranceService.GetAllInsurance();


            if (entity == null)
            {
                return NotFound();
            }


            return View(entity);
        }
        [HttpGet]
        [Route("Insurance/GetInsuranceDetail/{InsuranceId}")]
        public async Task<IActionResult> GetInsuranceDetail(int InsuranceId)
        {
            var entity = await _insuranceService.GetInsuranceById(InsuranceId.ToString());

            if (entity == null)
            {
                throw new NotFoundException(nameof(InsuranceDTO), InsuranceId);
            }

            return View(new InsuranceDTO
            {
                InsuranceId = entity.InsuranceId,
                Insurer = entity.Insurer ?? string.Empty,
                InsuranceName = entity.InsuranceName ?? string.Empty,
                InsuranceType = entity.InsuranceType ?? string.Empty,
              

            });


         
        }

        [HttpGet]
        [Route("Insurance/GetInsuranceByCarrier/{CarrierId}")]
        public async Task<IActionResult> GetInsuranceByCarrier(Guid CarrierId)
        {
            var entity = await _insuranceService.GetInsuranceByCarrier(CarrierId.ToString());


            if (entity == null)
            {
                return NotFound();
            }


            return View(entity);
        }

        [HttpGet]
        [Route("Insurance/GetInsuranceList")]
        public async Task<IActionResult> GetInsuranceList()
        {
            var entity = await _insuranceService.GetAllInsurance();


            if (entity == null)
            {
                return NotFound();
            }


            return View(entity);

        }


        public IActionResult AddInsurance()
        {
            return View();
        }
        [HttpPost]
        [Route("Insurance/AddInsurance")]
        public async Task<IActionResult> AddInsurance(Insurance command)
        {
            bool result = await _insuranceService.AddInsurance(command);

            //var result = await _mediator.Send(command);
            if (result)
            {

                return View(new ResultMsg { Msg = "Added New Insurance Entry  " });


            }

            else { return NotFound(); }
        }


        [HttpPost]
        [Route("Insurance/DeleteInsurance")]
        public async Task<IActionResult> DeleteInsurance(string command)
        {
            bool result = await _insuranceService.DeleteInsurance(command);

            //var result = await _mediator.Send(command);
            if (result)
            {

                return View(new ResultMsg { Msg = "Record Deleted " });


            }

            else { return NotFound(); }
        }

    }


}