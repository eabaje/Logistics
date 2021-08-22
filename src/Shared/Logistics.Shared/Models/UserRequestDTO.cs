using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Shared.Models
{
    public class UserRequestDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string FullName { get; set; }

        //[Required(ErrorMessage = "Name is required")]
        //public string FirstName { get; set; }

        //[Required(ErrorMessage = "Name is required")]
        //public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        public string UserName { get; set; }
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and confirm password is not matched")]
        public string ConfirmPassword { get; set; }

        public bool EmailConfirmed { get; set; }
    }
}
