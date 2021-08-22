using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logistics.AdminUI.Helper
{
    public   class PageWebHelper
    {
       // private static IUserService _IUserStore;
        private static IDriverRepository _driverService;
        static PageWebHelper _instance;
        private static IVehicleRepository _vehicleService;
        private static IFireBaseAuthService _authservice;
        private static ICompanyRepository _companyService;

        public static PageWebHelper Instance
        {
            get { return _instance ?? (_instance = new PageWebHelper()); }
        }



        //public  PageWebHelper(IUserService IUserStore, IDriverService DriverStore, IVehicleService vehicleService, IFireBaseAuthService authservice)
        //{
        //    if (IUserStore == null)
        //        throw new ArgumentNullException(nameof(IUserStore));
        //    _IUserStore = IUserStore;
        //    _driverService = DriverStore;
        //    _authservice = authservice;
        //  //  _companyService = companyService;
        //    _vehicleService = vehicleService;
        //}

        public  async Task< List<SelectListItem>> GetCompany(string company, ICompanyService companyService) 
                                                
        {
            _companyService = companyService;

            var entity = await  _companyService.GetCompanyByCategory(company);

            List <SelectListItem> Company = entity
                   .OrderBy(n => n.CompanyName)
                       .Select(n =>
                       new SelectListItem
                       {
                           Value = n.CompanyId.ToString(),
                           Text = n.CompanyName
                       }).ToList();
       //    ViewBag.CategoryList = Category;
            return Company;
        }

        public  async Task<List<SelectListItem>> GetDriversByCompany(string Companyid, IDriverService DriverStore)

        {
            _driverService = DriverStore;
            var entity = await _driverService.GetDriverByCarrier(Companyid);

            List<SelectListItem> DriverList = entity
                   .OrderBy(n => n.CompanyId)
                       .Select(n =>
                       new SelectListItem
                       {
                           Value = n.DriverId.ToString(),
                           Text = n.DriverName
                       }).ToList();
          
            return DriverList;
        }



        public  async Task<List<SelectListItem>> GetVehiclesByCompany(string Companyid, IVehicleService vehicleService)

        {
            _vehicleService = vehicleService;
            var entity = await _vehicleService.GetVehicleByCarrier(Companyid);

            List<SelectListItem> VehicleList = entity
                   .OrderBy(n => n.VehicleModel)
                       .Select(n =>
                       new SelectListItem
                       {
                           Value = n.VehicleId.ToString(),
                           Text = n.VehicleMake +"|" + n.VehicleModel +"|"+n.VehicleType
                       }).ToList();

            return VehicleList;
        }
    }
}
