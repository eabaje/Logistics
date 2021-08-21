using Carrier.Application.CQRS.CompanyRW.Commands;
using Carrier.Application.CQRS.LoginRW.Commands;
using Carrier.Application.CQRS.TrackerRW.Commands;
using Carrier.Application.CQRS.TrackerRW.Query;
using Carrier.Application.DTO;
using Logistics.Service.API.Repository.Interfaces;
using Carrier.FirebaseServer.Repository;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Logistics.Service.API.Controllers
{ 
    public class TrackController : Controller
    { 
    private readonly IMediator _mediator;
        private readonly IConfiguration _config;
        private IUserService _IUserStore;
        private IInsuranceService _insuranceService;
        private IFireBaseAuthService _authservice;
        private readonly IJourneyService _journeyService;
        //private FireBaseAuthService _authservice = new FireBaseAuthService();


        public TrackController(IConfiguration config, IUserService IUserStore, IJourneyService journeyService, IFireBaseAuthService authservice)
        {
            if (IUserStore == null)
                throw new ArgumentNullException(nameof(IUserStore));
            _IUserStore = IUserStore;
            _journeyService = journeyService;
            _authservice = authservice;
            _config = config;


        }





        public TrackController(IMediator mediator)
        {
            if (mediator == null)
                throw new ArgumentNullException(nameof(mediator));

            _mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }


    [HttpGet]
        [Route("Track/{TrackId}")]
        public async Task<IActionResult> GetTrackDetail(Guid TrackId)
        {
            var model = await _mediator.Send(new GetTrackDetail { TrackerId = TrackId });
            if (model == null)
                return NotFound();




            return View(model);
        }

        [HttpGet]
        [Route("Track/")]
        public async Task<IActionResult> GetTrackList()
        {
            var model = await _mediator.Send(new GetTrackList {} );
            if (model == null)
                return NotFound();


            return View(model);
        }

         [HttpPost]
        [Route("Track/AddTRack")]
        public async Task<IActionResult> AddTrack(AddTrack command)
        {
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {

                return  View(new ResultMsg { Msg = "New Tracking info added to our system " });
               
                
            }
            else
            {

                return null;
            }

           
        }
    }
}
