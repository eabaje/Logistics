using Logistics.Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
// using Google.Cloud.Firestore;
// [JsonProperty.Json;

namespace Logistics.Shared.Models
{
    // FreightCarrier
    public class CarrierDTO 
    {
        // [JsonProperty(PropertyName = "carrierId")]
        
        public Guid CarrierId { get; set; }
      

        // [JsonProperty(PropertyName = "companyId")]
        public int CompanyId { get; set; }

        // [JsonProperty(PropertyName = "carrierType")]
        public CarrierType CarrierType { get; set; }

        // [JsonProperty(PropertyName = "fleetType")]
        public FleetType FleetType { get; set; }

        // [JsonProperty(PropertyName = "fleetNumber")]
        public int FleetNumber { get; set; }

        // [JsonProperty(PropertyName = "licensed")]
        public bool? Licensed { get; set; }

        //// [JsonProperty(PropertyName = "insuranceId")]
        public string Company { get; set; }
    }
}
