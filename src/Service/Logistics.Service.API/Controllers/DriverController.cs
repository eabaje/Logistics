
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logistics.Service.API.Controllers
{
    public class DriverController : Controller
    {
        private readonly IConfiguration _config;
        private IUserService _IUserStore;
        private IDriverService _driverService;
        private IFireBaseAuthService _authservice;
        private ICompanyService _companyService;

        //private FireBaseAPageWebHelper helper = new PageWebHelper();uthService _authservice = new FireBaseAuthService();
        

        public DriverController(ICompanyService companyService, IConfiguration config, IUserService IUserStore, IDriverService DriverStore, IFireBaseAuthService authservice)
        {
            if (IUserStore == null)
                throw new ArgumentNullException(nameof(IUserStore));
            _IUserStore = IUserStore;
            _driverService = DriverStore;
            _authservice = authservice;
            _config = config;
            _companyService = companyService;

        }
       


       
        public async Task<IActionResult> Index()
        {
            var entity = await _companyService.GetCompanyByCategory("carrier");

            List<SelectListItem> Category = entity
                   .OrderBy(n => n.CompanyId)
                       .Select(n =>
                       new SelectListItem
                       {
                           Value = n.CompanyId.ToString(),
                           Text = n.CompanyName
                       }).ToList();





            ViewBag.CategoryList = Category;
            return View();
        }

        [HttpGet]
        [Route("Driver/GetDriver/{DriverId}")]
        public async Task<IActionResult> GetDriver(string DriverId)
        {
            var entity = await _driverService.GetItemAsync(DriverId.ToString());

            if (entity == null)
            {
                throw new NotFoundException(nameof(DriverDTO), DriverId);
            }

            return View(new DriverDTO
            {
                DriverId = entity.DriverId,
                DriverName = entity.DriverName ?? string.Empty,
                DriverLicense = entity.DriverLicense ?? string.Empty,
                Phone = entity.Phone ?? string.Empty,
                Email = entity.Email ?? string.Empty,
                City = entity.City ?? string.Empty,
                Address = entity.Address ?? string.Empty,
                Company = entity.CompanyId.ToString() ?? string.Empty,
                Country = entity.Country ?? string.Empty,
                Picture = entity.PicturePath ?? string.Empty,
            });


         
        }

        [HttpGet]
        [Route("Driver/")]
        public async Task<IActionResult> GetDriverList()
        {
            var entity = await _driverService.GetAllDrivers();


            if (entity == null)
            {
                return NotFound();
            }


            return View(entity);

            
        }

        public async Task<IActionResult> AddDriver()
        {
         

              ViewBag.CompanyList =  await Helper.PageWebHelper.Instance.GetCompany("carrier",_companyService);

            return View();

          
        }

        [HttpPost]
        [Route("Driver/AddDriver")]
        public async Task<IActionResult> AddDriver(VehicleDriver command)
        {
            bool result = await _driverService.AddDriver(command);

            //var result = await _mediator.Send(command);
            if (result)
            {

                return View(new ResultMsg { Msg = "Added New Driver Info " });

                //Login Info Mail sent to driver 


            }

            else { return NotFound(); }

           
        }


        [HttpPost]
        [Route("Driver/DeleteDriver")]
        public async Task<IActionResult> DeleteDriver(string command)
        {
            bool result = await _driverService.DeleteDriver(command);

            //var result = await _mediator.Send(command);
            if (result)
            {

                return View(new ResultMsg { Msg = "Record Deleted " });


            }

            else { return NotFound(); }
        }



        public IActionResult AssignVehicle()
        {
            ViewBag.CompanyList = Helper.PageWebHelper.Instance.GetCompany("carrier",_companyService);

            return View();


        }
    }
}