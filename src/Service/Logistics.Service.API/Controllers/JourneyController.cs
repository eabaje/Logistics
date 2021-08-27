
using Logistics.Service.API.Entities;
using Logistics.Service.API.Repository.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Logistics.Service.API.Controllers
{
    public class JourneyController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _config;
        private IUserService _IUserStore;
        private IInsuranceService _insuranceService;
        private IFireBaseAuthService _authservice;
        private readonly IJourneyService _journeyService;
        private ICompanyService _companyService;
        //private FireBaseAuthService _authservice = new FireBaseAuthService();


        public JourneyController(ICompanyService companyService, IConfiguration config, IUserService IUserStore, IJourneyService journeyService, IFireBaseAuthService authservice)
        {
            if (IUserStore == null)
                throw new ArgumentNullException(nameof(IUserStore));
            _IUserStore = IUserStore;
            _journeyService = journeyService;
            _authservice = authservice;
            _config = config;
            _companyService = companyService;

        }

       
       


       
        public async Task<IActionResult> Index()
        {
            var entity = await _journeyService.GetAllJourneys();


            if (entity == null)
            {
                return NotFound();
            }


            return View(entity);
        }

        public async Task<IActionResult> AddJourney()
        {

            ViewBag.CompanyList = await Helper.PageWebHelper.Instance.GetCompany("carrier", _companyService);

            return View();
        }


        [HttpGet]
        [Route("Journey/GetJourneyDetail/{JourneyId}")]
        public async Task<IActionResult> GetJourneyDetail(int JourneyId)
        {
            var entity = await _journeyService.GetJourneyById(JourneyId.ToString());

            if (entity == null)
            {
                throw new NotFoundException(nameof(JourneyDTO), JourneyId);
            }

            return View(new JourneyDTO
            {
                Id = entity.Id,
                DriverId = entity.DriverId,
                VehicleId = entity.VehicleId,
                JourneyStatus = entity.JourneyStatus ?? string.Empty,
                StartLocation = entity.StartLocation ?? string.Empty,
                Destination = entity.Destination ?? string.Empty,
                StartDate = entity.StartDate,
                ArrivalDate = entity.ArrivalDate,
                TotalDistance = entity.TotalDistance ?? string.Empty,
                TravelTime = entity.TravelTime ?? string.Empty,
                RestTime = entity.RestTime ?? string.Empty,
                ReportsTo = entity.ReportsTo ?? string.Empty,
                Comment = entity.Comment ?? string.Empty

            });




        }

        [HttpGet]
        [Route("Journey/GetJourneyByCarrier/{CarrierId}")]
        public async Task<IActionResult> GetJourneyByCarrier(Guid CarrierId)
        {
            var entity = await _journeyService.GetJourneyByCarrier(CarrierId.ToString());


            if (entity == null)
            {
                return NotFound();
            }


            return View(entity);
        }

        [HttpGet]
        [Route("Journey/GetJourneyList")]
        public async Task<IActionResult> GetJourneyList()
        {
            var entity = await _journeyService.GetAllJourneys();


            if (entity == null)
            {
                return NotFound();
            }


            return View(entity);

        }

        [HttpPost]
        //[Route("Journey/AddJourney")]
        public async Task<IActionResult> AddJourney(Journey command)
        {
            bool result = await _journeyService.AddJourney(command);

            //var result = await _mediator.Send(command);
            if (result)
            {

                return View(new ResultMsg { Msg = "Added New Journey Entry  " });


            }

            else { return NotFound(); }
        }


        [HttpPost]
        [Route("Journey/DeleteJourney")]
        public async Task<IActionResult> DeleteJourney(string command)
        {
            bool result = await _journeyService.DeleteJourney(command);

            //var result = await _mediator.Send(command);
            if (result)
            {

                return View(new ResultMsg { Msg = "Record Deleted " });


            }

            else { return NotFound(); }
        }

    }
}