﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Shared.Models
{
    public class UserDTO
    {
        public string Id { get; set; }

        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
         public string Email { get; set; }
        public string Phone { get; set; }
       
        public string PhoneNo { get; set; }
    }

    public class UserNameDTO
    {
       
        public string Email { get; set; }
       
    }

}
