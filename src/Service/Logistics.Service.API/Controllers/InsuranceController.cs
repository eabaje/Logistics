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
    public class InsuranceController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly ILogger<InsuranceController> _logger;
        private IInsuranceRepository _repository;

        public InsuranceController(IConfiguration config, IInsuranceRepository repository, ILogger<InsuranceController> logger, IMapper mapper)
        {

            _repository = repository;
            _mapper = mapper;
            _config = config;

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }



        [HttpGet]
        [Route("Insurance/{InsuranceId}")]
        public async Task<IActionResult> GetInsurance(string InsuranceId)
        {
            try
            {
                var entity = await _repository.GetItemAsync(InsuranceId);

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
        // [Route("Insurance/GetFreightInsuranceByDate/{InsuranceId}")]
        public async Task<ActionResult<IEnumerable<InsuranceDTO>>> GetInsuranceHistoryByDate([FromBody] string fromdate, string todate, string InsuranceId)
        {
            try
            {
                var entity = await _repository.GetInsuranceByDate(Convert.ToDateTime(fromdate), Convert.ToDateTime(todate), InsuranceId);

                if (entity == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<List<InsuranceDTO>>(entity));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        [HttpGet]
        [Route("Insurance/")]
        public async Task<IActionResult> GetInsuranceList()
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
        // [Route("Insurance/AddDriver")]
        public async Task<IActionResult> AddInsuranceProfile(InsuranceDTO Insurancedto)
        {
            try
            {
                var entity = await _repository.AddItemAsync(_mapper.Map<Insurance>(Insurancedto));



                return Ok(entity);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }



        [HttpPut]
        // [Route("Insurance/AddDriver")]
        public async Task<IActionResult> UpdateInsuranceProfile(InsuranceDTO Insurancedto)
        {
            try
            {
                var entity = await _repository.UpdateItemAsync(_mapper.Map<Insurance>(Insurancedto));



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