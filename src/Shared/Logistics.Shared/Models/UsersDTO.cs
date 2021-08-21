
using Logistics.Shared.Models;
// [JsonProperty.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Logistics.Shared.Models
{
    public class UsersDTO
    {

        [DisplayName("User Id")]
        public string LocalId { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }


        public Company Company { get; set; }

        [DisplayName("Category")]
        public string Category { get; set; }

        [DisplayName("Address")]
        public string Address { get; set; }

        [DisplayName("Phone")]
        public string Phone { get; set; }

        [DisplayName("Role")]
        public string Role { get; set; }

        [DisplayName("Password")]
        public string Password { get; set; }

        [DisplayName("Comfirm Password")]
        public string ConfirmPassword { get; set; }

        [DisplayName("Date of Registration")]
        public DateTime? RegisterDate { get; set; }

        public IEnumerable<Company> CompanyList { get; set; }

        [DisplayName("FullName")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
    }


    public class FirebaseUserInfo
    {
        // [JsonProperty(PropertyName = "identities")]
        public FirebaseIdentities Identities { get; set; }

        // [JsonProperty(PropertyName = "sign_in_provider")]
        public string SignInProvider { get; set; }
    }

    public class FirebaseIdentities
    {
        // [JsonProperty(PropertyName = "facebook.com")]
        public string[] FacebookDotCom { get; set; }

        // [JsonProperty(PropertyName = "google.com")]
        public string[] GoogleDotCom { get; set; }

        // [JsonProperty(PropertyName = "email")]
        public string[] Email { get; set; }
    }
}
