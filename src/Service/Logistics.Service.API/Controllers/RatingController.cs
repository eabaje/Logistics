using Carrier.Application.CQRS.CompanyRW.Commands;
using Carrier.Application.CQRS.LoginRW.Commands;
using Carrier.Application.CQRS.RatingRW.Commands;
using Carrier.Application.CQRS.RatingRW.Query;
using Carrier.Application.DTO;
using Carrier.Application.Exceptions;
using Logistics.Service.API.Entities;

using Logistics.Service.API.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Logistics.Service.API.Controllers
{
    public class RatingController : Controller
    {
        private readonly IMediator _mediator;
        private readonly RatingService _ratingService;
        //private readonly VehicleService _vehicleService;
        public RatingController(RatingService ratingService)
        {
            if (ratingService == null)
                throw new ArgumentNullException(nameof(ratingService));

            _ratingService = ratingService;

        }
       
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("Rating/{RatingId}")]
        public async Task<IActionResult> GetRatingDetail(int RatingId)
        {
            var entity = await _ratingService.GetRatingById(RatingId.ToString());

            if (entity == null)
            {
                throw new NotFoundException(nameof(RatingDTO), RatingId);
            }

            return View(new RatingDTO
            {
                RatingId = entity.RatingId,
                Score = entity.Score,
                Recipient = entity.Recipient ?? string.Empty,
               


            });


          
        }

        [HttpGet]
        [Route("Rating/")]
        public async Task<IActionResult> GetRatingList()
        {
            var entity = await _ratingService.GetAllRatings();

            if (entity == null)
            {
                throw new NotFoundException(nameof(RatingDTO), null);
            }


            return View(entity);


        
        }
        public IActionResult AddRating()
        {
            return View();
        }
        [HttpPost]
        [Route("Rating/AddRating")]
        public async Task<IActionResult> AddRating(Rating command)
        {
            bool result = await _ratingService.AddRating(command);

            //var result = await _mediator.Send(command);
            if (result)
            {

                return View(new ResultMsg { Msg = "Added New Rating   " });


            }

            else { return NotFound(); }
           
        }



        [HttpGet]
        [Route("Rating/DeleteRating/{DeleteRating}")]
        public async Task<IActionResult> DeleteRating(int RatingId)
        {
            bool result = await _ratingService.DeleteRating(RatingId.ToString());

            if (result)
            {

                return View(new ResultMsg { Msg = "Record Deleted  " });


            }

            else { return NotFound(); }


        }

    }
}