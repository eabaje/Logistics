// [JsonProperty.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Logistics.Shared.Models
{
   public  class TrackerDTO
    {
        // [JsonProperty(PropertyName = "trackId")]
       
        public Guid TrackId { get; set; }
      

        // [JsonProperty(PropertyName = "journeyId")]
        public int JourneyId { get; set; }

        // [JsonProperty(PropertyName = "longitude")]
        public string Longitude { get; set; }

        // [JsonProperty(PropertyName = "latitude")]
        public string Latitude { get; set; }

        // [JsonProperty(PropertyName = "trackDate")]
        public DateTime? TrackDate { get; set; }

        // [JsonProperty(PropertyName = "trackTime")]
        public string TrackTime { get; set; }
       
        public string Journey { get; set; }
    }
}
