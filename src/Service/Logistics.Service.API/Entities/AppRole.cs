using System;
using Microsoft.AspNetCore.Identity;

namespace Logistics.Service.API.Entities
{
    public class AppRole : IdentityRole
    {
        public string Description { get; set; }
        public DateTime CreatedDated { get; set; }
        public string IPAddress { get; set; }
    }
}
