using System;
using System.Collections.Generic;
using System.Text;

namespace Logistics.Service.API.Entities
{
    public class User
    {
        public string Lastname { get; set; }
        public string Othernames { get; set; }
        public string Company { get; set; }

        public long Supervisor { get; set; }
        public string FullName
        {
            get
            {
                return Lastname + ", " + Othernames;
            }
        }

        public DateTime? LastLoginTime { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? LastLockedDate { get; set; }
        public bool? IsSuperUser { get; set; }
        public bool? ForceChangeOfPassword { get; set; }
        public DateTime? LastDatePasswordWasChanged { get; set; }
    }
}
