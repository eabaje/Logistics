using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Logistics.Service.API.Entities;
using Logistics.Service.API.Repository;
using Logistics.Service.API.Repository.Interfaces;
using Logistics.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Logistics.Service.API.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly ILogger<VehicleController> _logger;
        private IVehicleRepository _repository;

        public VehicleController(IConfiguration config, IVehicleRepository repository, ILogger<VehicleController> logger, IMapper mapper)
        {

            _repository = repository;
            _mapper = mapper;
            _config = config;

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }




        [HttpGet]
        [Route("Vehicle/{VehicleId}")]
        public async Task<IActionResult> GetVehicle(string VehicleId)
        {
            try
            {
                var entity = await _repository.GetItemAsync(VehicleId);

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
        // [Route("Vehicle/GetFreightVehicleByDate/{VehicleId}")]
        public async Task<ActionResult<IEnumerable<VehicleDTO>>> GetVehicleHistoryByDate([FromBody] string fromdate, string todate, string VehicleId)
        {
            try
            {
                var entity = await _repository.GetVehicleHistoryByDate(Convert.ToDateTime(fromdate), Convert.ToDateTime(todate), VehicleId);

                if (entity == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<List<VehicleDTO>>(entity));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        [HttpGet]
        [Route("Vehicle/")]
        public async Task<IActionResult> GetVehicleList()
        {
            try
            {
                var entity = await _repository.GetItemsAsync();

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
        // [Route("Vehicle/AddDriver")]
        public async Task<IActionResult> AddVehicleProfile(VehicleDTO Vehicledto)
        {
            try
            {
                var entity = await _repository.AddItemAsync(_mapper.Map<Vehicle>(Vehicledto));



                return Ok(entity);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }



        [HttpPut]
        // [Route("Vehicle/AddDriver")]
        public async Task<IActionResult> UpdateVehicleProfile(VehicleDTO Vehicledto)
        {
            try
            {
                var entity = await _repository.UpdateItemAsync(_mapper.Map<Vehicle>(Vehicledto));



                return Ok(entity);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}