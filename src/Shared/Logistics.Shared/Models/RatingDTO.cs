using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
// using Google.Cloud.Firestore;
// [JsonProperty.Json;

namespace Logistics.Shared.Models
{
   public  class RatingDTO
    {
        // [JsonProperty(PropertyName = "ratingId")]
        
        public Guid RatingId { get; set; }

        // [JsonProperty(PropertyName = "score")]
        public int Score { get; set; }

        // [JsonProperty(PropertyName = "recipient")]
        public string Recipient { get; set; }
     

    }
}
