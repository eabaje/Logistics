using Logistics.Shared.Enumerations;
// [JsonProperty.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Logistics.Shared.Models
{
    public class VesselDTO
    {

        public Guid VesselId { get; set; }

       
        public string IMO { get; set; }

       
        public string MMSI { get; set; }

       
        public string CallSign { get; set; }

      
        public string Flag { get; set; }

       
        public string FleetNumber { get; set; }

       
        public string VesselType { get; set; }

      
        public string LengthBreadth { get; set; }

       
        public string DeadWeight { get; set; }

       
        public string GrossTonnage { get; set; }

       
        public System.DateTime? YearBuilt { get; set; }

       
     //   public string Company { get; set; }
    }
}
