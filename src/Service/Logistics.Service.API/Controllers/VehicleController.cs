using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carrier.Application.CQRS.VehicleRW.Commands;
using Carrier.Application.CQRS.VehicleRW.Query;
using Carrier.Application.DTO;
using Carrier.Application.Exceptions;
using Logistics.Service.API.Entities;
using Logistics.Service.API.Repository.Interfaces;
using Carrier.FirebaseServer.Repository;

using Logistics.Service.API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace Logistics.Service.API.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IDriverService _driverService;
      
        private readonly IConfiguration _config;
        private IVehicleService _vehicleService;
        private ICompanyService _companyService;
        private IConsignmentService _consignmentService;
        private IFireBaseAuthService _authservice;
        private readonly IJourneyService _journeyService;
        //private FireBaseAuthService _authservice = new FireBaseAuthService();


        public VehicleController(IDriverService driverService,ICompanyService companyService, IConfiguration config, IVehicleService vehicleService, IConsignmentService consignmentService, IFireBaseAuthService authservice)
        {
          
            _vehicleService = vehicleService;
            _consignmentService = consignmentService;
            _authservice = authservice;
            _config = config;
            _companyService = companyService;
            _driverService = driverService;

        }


       
        public async Task<IActionResult> Index()
        {
            var entity = await _companyService.GetCompanyByCategory("carrier");

            List<SelectListItem> Category = entity
                   .OrderBy(n => n.CompanyId)
                       .Select(n =>
                       new SelectListItem
                       {
                           Value = n.CompanyId.ToString(),
                           Text = n.CompanyName
                       }).ToList();





            ViewBag.CategoryList = Category;
            return View();
        }

       

        public async Task<IActionResult> EditVehicle(string VehicleId)
        {
            var entityCompany = await _companyService.GetCompanyByCategory("carrier");

            List<SelectListItem> Category = entityCompany
                   .OrderBy(n => n.CompanyId)
                       .Select(n =>
                       new SelectListItem
                       {
                           Value = n.CompanyId.ToString(),
                           Text = n.CompanyName
                       }).ToList();





            ViewBag.CategoryList = Category;


            var entity = await _vehicleService.GetItemAsync(VehicleId.ToString());

            if (entity == null)
            {
                throw new NotFoundException(nameof(VehicleDTO), VehicleId);
            }

            return View(new VehicleDTO
            {
                VehicleId = entity.VehicleId,
                CarrierId = entity.CarrierId,
                VehicleType = entity.VehicleType,
                VehicleNumber = entity.VehicleNumber,
                SerialNumber = entity.SerialNumber ?? string.Empty,
                VehicleMake = entity.VehicleMake,
                VehicleColor = entity.VehicleColor,
                VehicleModel = entity.VehicleModel,
                LicensePlate = entity.LicensePlate,
                VehicleModelYear = entity.VehicleModelYear
            });


          //  return View();
        }

        [HttpGet]
        [Route("Vehicle/GetVehicleDetail/{VehicleId}")]
        public async Task<IActionResult> GetVehicleDetail(int VehicleId)
        {
            var entity = await _vehicleService.GetItemAsync(VehicleId.ToString());

            if (entity == null)
            {
                throw new NotFoundException(nameof(VehicleDTO), VehicleId);
            }

            return View(new VehicleDTO
            {
                VehicleId = entity.VehicleId,
                CarrierId = entity.CarrierId,
                VehicleType = entity.VehicleType,
                VehicleNumber = entity.VehicleNumber,
                SerialNumber = entity.SerialNumber ?? string.Empty,
                VehicleMake = entity.VehicleMake,
                VehicleColor = entity.VehicleColor,
                VehicleModel = entity.VehicleModel,
                LicensePlate = entity.LicensePlate,
                VehicleModelYear = entity.VehicleModelYear
            });

        

          
        }

        [HttpGet]
        [Route("Vehicle/")]
        public async Task<IActionResult> GetVehicleList()
        {
            var entity = await _vehicleService.GetAllVehicles();

            if (entity == null)
            {
                throw new NotFoundException(nameof(VehicleDTO),null);
            }

           
            return View(entity);
        }


        public IActionResult AddVehicle()
        {

            return View();
        }


        [HttpPost]
      //  [Route("Vehicle/AddVehicle")]
        public async Task<IActionResult> AddVehicle(Vehicle command)
        {
           bool result= await _vehicleService.AddVehicle(command);

            //var result = await _mediator.Send(command);
            if (result)
            {

                return View(new ResultMsg { Msg = "New Vehicle Registered in our system " });


            }

            else { return NotFound(); }
        }


        [HttpPost]
        [Route("Vehicle/DeleteVehicle")]
        public async Task<IActionResult> DeleteVehicle(string command)
        {
            bool result = await _vehicleService.DeleteVehicle(command);

            //var result = await _mediator.Send(command);
            if (result)
            {

                return View(new ResultMsg { Msg = "Record Deleted " });


            }

            else { return NotFound(); }
        }
    }
}