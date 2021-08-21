using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
// using Google.Cloud.Firestore;
// [JsonProperty.Json;

namespace Logistics.Shared.Models
{
   public class AssignVehicleDTO
    {
        // [JsonProperty(PropertyName = "assignId")]
           
        public Guid AssignId { get; set; }
        // [JsonProperty(PropertyName = "assignedDate")]
        public DateTime? AssignedDate { get; set; }

        // [JsonProperty(PropertyName = "duration")]
        public string Duration { get; set; }

        // [JsonProperty(PropertyName = "purpose")]
        public string Purpose { get; set; }

        // [JsonProperty(PropertyName = "comments")]
        public string Comments { get; set; }

        // [JsonProperty(PropertyName = "driverId")]
        public string DriverId { get; set; }

        // [JsonProperty(PropertyName = "vehicleId")]
        public string VehicleId { get; set; }

     

      

    }
}
