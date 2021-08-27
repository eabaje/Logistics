
using AutoMapper;
using Logistics.Service.API.Entities;
using Logistics.Service.API.Repository.Interfaces;
using Logistics.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logistics.Service.API.Controllers
{
    public class DriverController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly ILogger<DriverController> _logger;
        private IDriverRepository _repository;

        //private FireBaseAPageWebHelper helper = new PageWebHelper();uthService _authservice = new FireBaseAuthService();


        public DriverController(IConfiguration config, IDriverRepository repository, ILogger<DriverController> logger, IMapper mapper)
        {

            _repository = repository;
            _mapper = mapper;
            _config = config;

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }




        [HttpGet]
        [Route("Driver/{DriverId}")]
        public async Task<IActionResult> GetDriver(string DriverId)
        {
            try
            {
                var entity = await _repository.GetDriverById(DriverId);

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
      //  [Route("Driver/{DriverId}")]
        public async Task<IActionResult> GetDriverByName(string driverName)
        {
            try
            {
                var entity = await _repository.GetDriverByName(driverName);

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
        // [Route("Driver/GetFreightDriverByDate/{DriverId}")]
        public async Task<ActionResult<IEnumerable<DriverDTO>>> GetDriverHistoryByDate([FromBody] string fromdate, string todate, string DriverId)
        {
            try
            {
                var entity = await _repository.GetDriverHistoryByDate(Convert.ToDateTime(fromdate), Convert.ToDateTime(todate), DriverId);

                if (entity == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<List<DriverDTO>>(entity));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        [HttpGet]
        [Route("Driver/")]
        public async Task<IActionResult> GetDriverList()
        {
            try
            {
                var entity = await _repository.GetAllDrivers();

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
        // [Route("Driver/AddDriver")]
        public async Task<IActionResult> AddDriverProfile([FromBody] DriverDTO Driverdto)
        {
            try
            {
                var entity = await _repository.AddDriver(_mapper.Map<VehicleDriver>(Driverdto));



                return Ok(entity);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }



        [HttpPut]
        // [Route("Driver/AddDriver")]
        public async Task<IActionResult> UpdateDriverProfile([FromBody] DriverDTO Driverdto)
        {
            try
            {
                var entity = await _repository.UpdateDriver(_mapper.Map<VehicleDriver>(Driverdto));



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