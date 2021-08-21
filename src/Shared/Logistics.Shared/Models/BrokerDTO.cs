// [JsonProperty.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logistics.Shared.Models
{
   public class BrokerDTO
    {
       
        public Guid BrokerId { get; set; }
       

    
        public string CompanyId { get; set; }

       
        public bool? Certified { get; set; }

     
        public String Experience { get; set; }

      
        public String JobScope { get; set; }

        public string SecondaryEmail { get; set; }
        public string Company { get; set; }

    }
}
