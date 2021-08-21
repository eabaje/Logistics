using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carrier.Application.DTO;
using Carrier.Application.Exceptions;
using Logistics.Service.API.Entities;
using Logistics.Service.API.Repository.Interfaces;
using Carrier.FirebaseServer.Repository;
using Logistics.Service.API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Logistics.Service.API.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _config;
        private IUserService _IUserStore;
        private IPaymentService _paymentService;
        private IFireBaseAuthService _authservice;
        private readonly IJourneyService _journeyService;
        //private FireBaseAuthService _authservice = new FireBaseAuthService();


        public PaymentController(IConfiguration config, IUserService IUserStore, IPaymentService paymentService, IFireBaseAuthService authservice)
        {
            if (IUserStore == null)
                throw new ArgumentNullException(nameof(IUserStore));
            _IUserStore = IUserStore;
            _paymentService = paymentService;
            _authservice = authservice;
            _config = config;


        }



        public async Task<IActionResult> Index()
        {
            var entity = await _paymentService.GetAllPayment();

            if (entity == null)
            {
                throw new NotFoundException(nameof(PaymentDTO), null);
            }
            var model = entity
              .Select(a => new PaymentDTO
              {
                  PaymentDate = a.PaymentDate,
                  PaymentId = a.PaymentId,
                  PaymentRef = a.PaymentRef ?? string.Empty,
                  PaymentTime = a.PaymentTime,
                  PaymentStatus = a.PaymentStatus,
                  Payer = a.Payer,
                  Recipient = a.Recipient,
                  Amount = a.Amount,
                  Currency = a.Currency,
              }).ToList();



            return View(model);
        }

        [HttpGet]
        [Route("Payment/GetPaymentDetail/{PaymentId}")]
        public async Task<IActionResult> GetPaymentDetail(int PaymentId)
        {
            var entity = await _paymentService.GetPaymentById(PaymentId.ToString());

            if (entity == null)
            {
                throw new NotFoundException(nameof(PaymentDTO), PaymentId);
            }

            return View(new PaymentDTO
            {
                PaymentDate = entity.PaymentDate ,
                PaymentId = entity.PaymentId,
                PaymentRef = entity.PaymentRef ?? string.Empty,
                PaymentTime = entity.PaymentTime,
                PaymentStatus = entity.PaymentStatus,
                Payer = entity.Payer,
                Recipient = entity.Recipient,
                Amount = entity.Amount,
                Currency = entity.Currency,
              //  Comment = entity.Comment ?? string.Empty,


            });




        }

        [HttpGet]
        [Route("Payment/EditPaymentt/{PaymentId}")]
        public async Task<IActionResult> EditPaymentt(int PaymentId)
        {
            var entity = await _paymentService.GetPaymentById(PaymentId.ToString());

            if (entity == null)
            {
                throw new NotFoundException(nameof(PaymentDTO), PaymentId);
            }

            return View(new PaymentDTO
            {
                PaymentDate = entity.PaymentDate,
                PaymentId = entity.PaymentId,
                PaymentRef = entity.PaymentRef ?? string.Empty,
                PaymentTime = entity.PaymentTime,
                PaymentStatus = entity.PaymentStatus,
                Payer = entity.Payer,
                Recipient = entity.Recipient,
                Amount = entity.Amount,
                Currency = entity.Currency,
                //  Comment = entity.Comment ?? string.Empty,


            });




        }

        [HttpPost]
        [Route("Payment/EditPayment")]

        public async Task<IActionResult> EditPayment(Payment command)
        {
            bool result = await _paymentService.UpdatePayment(command);

            //var result = await _mediator.Send(command);
            // Create a Logger,Audit Trail
            if (result)
            {
                //log changes 
                return View(new ResultMsg { Msg = "Updated New Payment Entry  " });


            }

            else { return NotFound(); }
        }


        [HttpGet]
        [Route("Payment/")]
        public async Task<IActionResult> GetPaymentList()
        {
            var entity = await _paymentService.GetAllPayment();

            if (entity == null)
            {
                throw new NotFoundException(nameof(PaymentDTO), null);
            }


            return View(entity);
        }




        public ActionResult AddPayment()
        {
           

                return View();


         
        }

        [HttpPost]
        [Route("Payment/AddPayment")]

        public async Task<IActionResult> AddPayment(Payment command)
        {
            bool result = await _paymentService.AddPayment(command);

            //var result = await _mediator.Send(command);
            if (result)
            {

                return View(new ResultMsg { Msg = "Added New Payment Entry  " });


            }

            else { return NotFound(); }
        }


        [HttpPost]
        [Route("Payment/DeletePayment")]
        public async Task<IActionResult> DeletePayment([FromBody]string command)
        {
            bool result = await _paymentService.DeletePayment(command);

            //var result = await _mediator.Send(command);
            if (result)
            {

                return View(new ResultMsg { Msg = "Record Deleted " });


            }

            else { return NotFound(); }
        }
    }
}