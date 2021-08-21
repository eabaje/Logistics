
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
// using Google.Cloud.Firestore;
// [JsonProperty.Json;

namespace Logistics.Shared.Models
{
   
   
 

    public  class JourneyDTO
    {

        // [JsonProperty(PropertyName = "id")]
        
        public Guid Id { get; set; }

        // [JsonProperty(PropertyName = "driverId")]
        public string DriverId { get; set; }

        // [JsonProperty(PropertyName = "vehicleId")]
        public string VehicleId{ get; set; }

        // [JsonProperty(PropertyName = "journeyStatus")]
        public string JourneyStatus { get; set; }

        // [JsonProperty(PropertyName = "startLocation")]
        public string StartLocation { get; set; }

        // [JsonProperty(PropertyName = "destination")]
        public string Destination { get; set; }

        // [JsonProperty(PropertyName = "startDate")]
        public DateTime StartDate { get; set; }

        // [JsonProperty(PropertyName = "arrivalDate")]
        public DateTime ArrivalDate { get; set; }

        // [JsonProperty(PropertyName = "totalDistance")]
        public string TotalDistance { get; set; }

        // [JsonProperty(PropertyName = "travelTime")]
        public string TravelTime { get; set; }

        // [JsonProperty(PropertyName = "RestTime")]
        public string RestTime { get; set; }

        // [JsonProperty(PropertyName = "ReportsTo")]
        public string ReportsTo { get; set; }

        // [JsonProperty(PropertyName = "Comment")]
        public string Comment { get; set; }

       
        public string Driver { get; set; }

     
    }
}
