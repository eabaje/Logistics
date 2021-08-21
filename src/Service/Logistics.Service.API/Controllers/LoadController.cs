using Carrier.Application.CQRS.CompanyRW.Commands;
using Carrier.Application.CQRS.LoginRW.Commands;
using Carrier.Application.DTO;
using Carrier.Application.Exceptions;
using Logistics.Service.API.Entities;
using Logistics.Service.API.Repository.Interfaces;
using Carrier.FirebaseServer.Repository;

using Logistics.Service.API.Models;
using Logistics.Service.API.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logistics.Service.API.Controllers
{
    public class LoadController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _config;
        private IUserService _IUserStore;
        private ICompanyService _companyService;
        private IConsignmentService _consignmentService;
        private IFireBaseAuthService _authservice;
        private readonly IJourneyService _journeyService;
        //private FireBaseAuthService _authservice = new FireBaseAuthService();


        public LoadController(ICompanyService companyService,IConfiguration config, IUserService IUserStore, IConsignmentService consignmentService, IFireBaseAuthService authservice)
        {
            if (IUserStore == null)
                throw new ArgumentNullException(nameof(IUserStore));
            _IUserStore = IUserStore;
            _consignmentService = consignmentService;
            _authservice = authservice;
            _config = config;
            _companyService = companyService;

        }
       

     
        public async Task<IActionResult> Index()
        {
            var entity = await _consignmentService.GetAllConsignments();

            var model = entity
               .Select(a => new ConsignmentDTO
               {
                   LoadId = a.LoadId,
                   LoadDate = a.LoadDate ,
                   LoadCategory = a.LoadCategory,
                   LoadType = a.LoadType,
                   LoadWeight = a.LoadWeight, // Remove
                   LoadUnit = a.LoadUnit,
                   CompanyId = Guid.Parse(a.CompanyId),
                   Description = a.Description
               }).ToList();

          

            return View(model);
        }


        public async Task<IActionResult> AddLoad()
        {
            //get list of carrier companies and load to select list
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


        [HttpGet]
        [Route("Load/GetConsignmentDetail/{LoadId}")]
        public async Task<IActionResult> GetConsignmentDetail(Guid LoadId)
        {
            var entity = await _consignmentService.GetConsignmentById(LoadId.ToString());

            if (entity == null)
            {
                throw new NotFoundException(nameof(ConsignmentDTO), LoadId);
            }

            return View(new ConsignmentDTO
            {
                CompanyId = Guid.Parse(entity.CompanyId),
                LoadCategory = entity.LoadCategory ?? string.Empty,
                LoadType = entity.LoadType ?? string.Empty,
                LoadUnit = entity.LoadUnit ,
                LoadWeight = entity.LoadWeight ,
                Description = entity.Description ?? string.Empty,
               

            });




        }

        //[HttpGet]
        //[Route("Load/")]
        //public async Task<IActionResult> GetConsignmentList()
        //{
        //    var entity = await _consignmentService.GetAllConsignments();

        //    if (entity == null)
        //    {
        //        throw new NotFoundException(nameof(ConsignmentDTO), null);
        //    }


        //    return View(entity);
        //}

        [HttpPost]
    //    [Route("Load/AddLoad")]
       
        public async Task<IActionResult> AddLoad(Consignment command)
        {
            bool result = await _consignmentService.AddConsignment(command);

            //var result = await _mediator.Send(command);
            if (result)
            {

                return View(new ResultMsg { Msg = "Added New Load Entry  " });


            }

            else { return NotFound(); }
        }


        [HttpPost]
      //  [Route("Consignment/DeleteConsignment")]
        public async Task<IActionResult> DeleteConsignment(string command)
        {
            bool result = await _consignmentService.DeleteConsignment(command);

            //var result = await _mediator.Send(command);
            if (result)
            {

                return View(new ResultMsg { Msg = "Record Deleted " });


            }

            else { return NotFound(); }
        }
    }
}