using AutoMapper;
using AutoMapper.Configuration;
using Logistics.Service.API.Entities;
using Logistics.Service.API.Repository.Interfaces;
using Logistics.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logistics.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly ILogger<CarrierController> _logger;
        private IFreightRepository _repository;

        //private readonly VehicleRepository _vehicleRepository;
        public CarrierController(IConfiguration config, IFreightRepository repository, ILogger<CarrierController> logger, IMapper mapper)
        {

            _repository = repository;
            _mapper = mapper;
            _config = config;

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }



        [HttpGet]
        [Route("Carrier/{CarrierId}")]
        public async Task<IActionResult> GetCarrier(string CarrierId)
        {
            try
            {
                var entity = await _repository.GetItemAsync(CarrierId);

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
       // [Route("Carrier/GetFreightCarrierByDate/{CarrierId}")]
        public async Task<ActionResult<IEnumerable<CarrierDTO>>> GetFreightCarrierByDate([FromBody] string fromdate,string todate,string carrierId)
        {
            try
            {
                var entity = await _repository.GetFreightCarrierByDate(Convert.ToDateTime(fromdate), Convert.ToDateTime(todate),carrierId);

                if (entity == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<List<CarrierDTO>>(entity));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }
        
        [HttpGet]
        [Route("Carrier/")]
        public async Task<IActionResult> GetCarrierList()
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
        // [Route("Carrier/AddDriver")]
        public async Task<IActionResult> AddCarrierProfile(CarrierDTO Carrierdto)
        {
            try
            {
                var entity = await _repository.AddItemAsync(_mapper.Map<Carrier>(Carrierdto));



                return Ok(entity);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }



        [HttpPut]
        // [Route("Carrier/AddDriver")]
        public async Task<IActionResult> UpdateCarrierProfile(CarrierDTO carrierdto)
        {
            try
            {
                var entity = await _repository.UpdateItemAsync(_mapper.Map<Carrier>(carrierdto));



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
