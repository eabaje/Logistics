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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Logistics.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly ILogger<ShipperController> _logger;
        private IShipperRepository _repository;

        public ShipperController(IConfiguration config, IShipperRepository repository, ILogger<ShipperController> logger, IMapper mapper)
        {

            _repository = repository;
            _mapper = mapper;
            _config = config;

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        [HttpGet]
        [Route("Shipper/{ShipperId}")]
        public async Task<IActionResult> GetShipper(string ShipperId)
        {
            try
            {
                var entity = await _repository.GetItemAsync(ShipperId);

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
        // [Route("Shipper/GetFreightShipperByDate/{ShipperId}")]
        public async Task<ActionResult<IEnumerable<ShipperDTO>>> GetShipperHistoryByDate([FromBody] string fromdate, string todate, string ShipperId)
        {
            try
            {
                var entity = await _repository.GetShipperHistoryByDate(Convert.ToDateTime(fromdate), Convert.ToDateTime(todate), ShipperId);

                if (entity == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<List<ShipperDTO>>(entity));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        [HttpGet]
        [Route("Shipper/")]
        public async Task<IActionResult> GetShipperList()
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
        // [Route("Shipper/AddDriver")]
        public async Task<IActionResult> AddShipperProfile(ShipperDTO Shipperdto)
        {
            try
            {
                var entity = await _repository.AddItemAsync(_mapper.Map<Shipper>(Shipperdto));



                return Ok(entity);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }



        [HttpPut]
        // [Route("Shipper/AddDriver")]
        public async Task<IActionResult> UpdateShipperProfile(ShipperDTO Shipperdto)
        {
            try
            {
                var entity = await _repository.UpdateItemAsync(_mapper.Map<Shipper>(Shipperdto));



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
