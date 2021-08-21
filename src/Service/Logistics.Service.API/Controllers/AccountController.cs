using Logistics.Infrastructure.Managers.Abstract;
using Logistics.Shared.Models;
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
    public class AccountController : Controller
    {

        private readonly IConfiguration _config;
        private  IUserService _IUserStore;
        private ICompanyService _ICompanyStore;
        private IFireBaseAuthService _authservice ;
        private readonly IEmailManager _emailClientSender;
        //private FireBaseAuthService _authservice = new FireBaseAuthService();


        public AccountController(IEmailManager emailClientSender,IConfiguration config,IUserService IUserStore,ICompanyService ICompanyStore, IFireBaseAuthService authservice)
        {
            if (IUserStore == null)
                throw new ArgumentNullException(nameof(IUserStore));
            _IUserStore = IUserStore;
            _ICompanyStore = ICompanyStore;
            _authservice = authservice;
            _config = config;
            _emailClientSender = emailClientSender;

        }
       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register(string ReturnUrl)
        {
            return View();
        }
        public IActionResult AddProfile(int CompanyId)
        {
            return View();
        }
       
        //[HttpGet]
        //[Route("Account/Profile/{cid}")]
        //public async Task<IActionResult> Profile(string cid)
        //{
           
        //    var entity = await _IUserStore.GetUserByCarrier(cid.ToString());

        //    if (entity == null)
        //    {
        //        throw new NotFoundException(nameof(UsersDTO), cid);
        //    }
          
        //    return View(entity);



          
        //}

        [HttpGet]
        [Route("Account/Profile/{uid}")]
        public async Task<IActionResult> Profile(string  uid)
        {

            //  var entity = await _IUserStore.GetItemAsync(uid) ;
          
            var entity = await _IUserStore.GetUserByUID(uid);
           


            var model = new UsersDTO
            {
                LocalId = entity.LocalId,
                LastName = entity.LastName ?? "No Last Name Provided",
                FirstName = entity.FirstName ?? "No First Name Provided",
               
                Email = entity.Email ?? "No Email Provided",
                Phone = entity.Phone ?? "No Phone Number Provided",
                Company = await  _ICompanyStore.GetCompanyById(Guid.Parse(entity.Company)),
                Category = entity.Category ?? "No Category found"
               
            };

            List<SelectListItem> Category = new List<SelectListItem>()
            {
                 new SelectListItem() {Text="Broker", Value="broker"},
                 new SelectListItem() { Text="Carrier", Value="carrier"},
                 new SelectListItem() { Text="Dealer", Value="dealer"},
                 new SelectListItem() { Text="Manufacturer", Value="shipper"},
                 new SelectListItem() { Text="Import / Export", Value="shipper"}
    };
          

                 ViewBag.CategoryList = Category;

            ViewBag.FullName = model.FullName;
            //if (entity == null)
            //{
            //    throw new NotFoundException(nameof(UsersDTO), uid);
            //}

            return View(model);




        }
        [HttpGet]
        [Route("Account/EditProfile/{uid}")]
        public async Task<IActionResult> EditProfile(string uid)
        {

            var entity = await _IUserStore.GetItemAsync(uid);

            if (entity == null)
            {
                throw new NotFoundException(nameof(UsersDTO), uid);
            }

            return View(entity);




        }

        [HttpPost]
        //[Route("EditProfile/{UserId}")]
        public async Task<IActionResult> EditProfile(Users command)
        {
            var result = await _IUserStore.UpdateItemAsync(command.LocalId,command);

          
            if (result)
            {
               
                     return View(new ResultMsg { Msg = " Your Profile has been updated successfully " });
            }

            else { return NotFound(); }




        }

        public IActionResult Dashboard()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string ReturnUrl)
        {
            if (TempData["IsPasswordChange"] != null)
            {
                ModelState.AddModelError("", "Password change successful. Please login with your new password.");
            }
            var model = new LoginViewModel
            {
                ReturnUrl = ReturnUrl

            };
            //  Session["ReturnUrl"] = ReturnUrl;
            return View(model);
        }




        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel command)
        {
            var result = await _authservice.LoginUser(command.UserName, command.Password);

           
         
            if (result.Succeeded) 
            {

                //get role and navigate to panel


                //
                return RedirectToAction("Profile", "Account", new { uid = result.link.User.LocalId });
             


                
                //ModelState.AddModelError("UserName", "Invalid login attempt.");

                //return BadRequest(ModelState);



            }

            return Ok();
        }




        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("Index", "Home");
            }

            return returnUrl;
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(Users command)
        {

            var pwd = Application.Helper.CryptoServices.CreateRandomPassword(8);
            var cmpGuid = System.Guid.NewGuid();
            var entityCompany = new Company
            {
                CompanyId = cmpGuid,
                CompanyName = command.Company,
                Email = command.Email,
                Phone = command.Phone ?? null,
                Category = command.Category,
                CreatedOn = command.RegisterDate ?? DateTime.Now
               

            };
            bool addFlag = await _ICompanyStore.AddItemAsync(entityCompany);
            if (addFlag)
            {


            
            var authlink   = await _authservice.CreateNewUser(command.Email, pwd);

            var entityUsers = new Users
            {
                Company = cmpGuid.ToString(),
                LastName = command.LastName,
                FirstName = command.FirstName,
                Email = command.Email,
                Phone = command.Phone?? null,
                Category = command.Category,
                RegisterDate = command.RegisterDate?? DateTime.Now,
                LocalId = authlink.link.User.LocalId

            };

           
            var result=  await _IUserStore.AddItemAsync(entityUsers);


         
            if (result)
            {
                    ViewBag.EmailTitle = "LoadBoard User Services";

                var plainTextContent = "Load Dispatch is your ideal partner with Load Board Services<b/>" +
             string.Format("Your  login password: New Password: <b>{0}</b>", pwd);
                var htmlContent = "<strong>"+ plainTextContent + "</strong>";

                    AccountViewModel Acc = new AccountViewModel { UserName = command.Email, Password = pwd, Message = "", Name = entityUsers.FirstName + " " + entityUsers.LastName };

                var msg = await _emailClientSender.SendTemplateEmail("",command.Email, entityUsers.FirstName +" "+ entityUsers.LastName, "Welcome to Load Dispatch",Acc,"");
                return RedirectToAction("Profile", "Account", new { uid = authlink.link.User.LocalId});
//, email= entityUsers.Email 

            }
           
           


            } 
            return Ok();
        }

        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<IActionResult> Profile(AddProfile command)
        //{
        //    var result = await _mediator.Send(command);
        //    if (result.IsSuccess)
        //    {

        //        return  View(new ResultMsg { Msg = "Profile Updated Successfully" });
               
                
        //    }

        //   return Ok();
        //}



        //[HttpGet]
        //[AllowAnonymous]
        //public ActionResult Profile(string ReturnUrl)
        //{
        //    if (TempData["IsPasswordChange"] != null)
        //    {
        //        ModelState.AddModelError("", "Password change successful. Please login with your new password.");
        //    }
        //    var model = new LoginViewModel
        //    {
        //        ReturnUrl = ReturnUrl

        //    };
        //    //  Session["ReturnUrl"] = ReturnUrl;
        //    return View(model);
        //}

    }

}
