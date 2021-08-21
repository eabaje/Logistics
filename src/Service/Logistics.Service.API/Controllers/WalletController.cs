using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carrier.Application.DTO;
using Carrier.Application.Exceptions;
using Logistics.Service.API.Entities;

using Logistics.Service.API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Logistics.Service.API.Controllers
{
    public class WalletController : Controller
    {
        private readonly WalletService _walletService;
        private readonly IMediator _mediator;
        //private readonly VehicleService _vehicleService;
        public WalletController(WalletService walletService)
        {
            if (walletService == null)
                throw new ArgumentNullException(nameof(walletService));

            _walletService = walletService;

        }

        public IActionResult Index()
        {
            return View();
        }



        [HttpGet]
        [Route("Wallet/{WalletId}")]
        public async Task<IActionResult> GetWalletDetail(int WalletId)
        {
            var entity = await _walletService.GetWalletById(WalletId.ToString());

            if (entity == null)
            {
                throw new NotFoundException(nameof(WalletDTO), WalletId);
            }

            return View(new WalletDTO
            {
                Uid = entity.Uid,
                Date = entity.Date,
                Amount = entity.Amount,
                Ref = entity.Ref,
                Status = entity.Status ?? string.Empty,
               
            });




        }

        [HttpGet]
        [Route("Wallet/")]
        public async Task<IActionResult> GetVehicleList()
        {
            var entity = await _walletService.GetAllWallet();

            if (entity == null)
            {
                throw new NotFoundException(nameof(VehicleDTO), null);
            }


            return View(entity);
        }

        [HttpPost]
        [Route("Wallet/AddWallet")]
        public async Task<IActionResult> AddVehicle(Wallet command)
        {
            bool result = await _walletService.AddWallet(command);

            //var result = await _mediator.Send(command);
            if (result)
            {

                return View(new ResultMsg { Msg = "Added New Wallet Entry  " });


            }

            else { return NotFound(); }
        }


        [HttpPost]
        [Route("Wallet/DeleteWallet")]
        public async Task<IActionResult> DeleteWallet(string command)
        {
            bool result = await _walletService.DeleteWallet(command);

            //var result = await _mediator.Send(command);
            if (result)
            {

                return View(new ResultMsg { Msg = "Record Deleted " });


            }

            else { return NotFound(); }
        }
    }
}
