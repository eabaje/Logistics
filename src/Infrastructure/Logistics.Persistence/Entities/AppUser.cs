using System;
using Microsoft.AspNetCore.Identity;



namespace Logistics.Persistence.Entities
{
   public  class AppUser : IdentityUser
    {
        
        public string LastName { get; set; }
        public string Othernames { get; set; }      
        public string Company { get; set; }
        public string Category { get; set; }
        public string FullName
        {
            get
            {
                return LastName + ", " + Othernames;
            }
        }

        public DateTime? LastLoginTime { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? LastLockedDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? ForceChangeOfPassword { get; set; }
        public DateTime? LastDatePasswordWasChanged { get; set; }
        public AppRole Role { get; set; }

    }
}
