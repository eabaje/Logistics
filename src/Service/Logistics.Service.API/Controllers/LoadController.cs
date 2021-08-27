
using Logistics.Service.API.Entities;
using Logistics.Service.API.Repository.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logistics.Shared.Models;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace Logistics.Service.API.Controllers
{
    public class LoadController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly ILogger<LoadController> _logger;
        private IConsignmentRepository _repository;

        //private readonly VehicleRepository _vehicleRepository;
        public LoadController(IConfiguration config, IConsignmentRepository repository, ILogger<LoadController> logger, IMapper mapper)
        {

            _repository = repository;
            _mapper = mapper;
            _config = config;

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }



      


        [HttpGet]
        [Route("Consignment/{ConsignmentId}")]
        public async Task<IActionResult> GetConsignment(string ConsignmentId)
        {
            try
            {
                var entity = await _repository.GetItemAsync(ConsignmentId);

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
        // [Route("Consignment/GetFreightConsignmentByDate/{ConsignmentId}")]
        public async Task<ActionResult<IEnumerable<ConsignmentDTO>>> GetFreightConsignmentByDate([FromBody] string fromdate, string todate, string ConsignmentId)
        {
            try
            {
                var entity = await _repository.GetConsignmentByDate(Convert.ToDateTime(fromdate), Convert.ToDateTime(todate), ConsignmentId);

                if (entity == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<List<ConsignmentDTO>>(entity));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        [HttpGet]
        [Route("Consignment/")]
        public async Task<IActionResult> GetConsignmentList()
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
        // [Route("Consignment/AddDriver")]
        public async Task<IActionResult> AddConsignment([FromBody]ConsignmentDTO Consignmentdto)
        {
            try
            {
                var entity = await _repository.AddItemAsync(_mapper.Map<Consignment>(Consignmentdto));



                return Ok(entity);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }



        [HttpPut]
        // [Route("Consignment/AddDriver")]
        public async Task<IActionResult> UpdateConsignment([FromBody] ConsignmentDTO Consignmentdto)
        {
            try
            {
                var entity = await _repository.UpdateItemAsync(_mapper.Map<Consignment>(Consignmentdto));



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