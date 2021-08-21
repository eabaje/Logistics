using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
// using Google.Cloud.Firestore;
// [JsonProperty.Json;

namespace Logistics.Shared.Models
{
   public class InsuranceDTO
    {


        // [JsonProperty(PropertyName = "insuranceId")]
        public Guid InsuranceId { get; set; }

        // [JsonProperty(PropertyName = "insuranceName")]
        public string InsuranceName { get; set; }

        // [JsonProperty(PropertyName = "insuranceType")]
        public string InsuranceType { get; set; }

        // [JsonProperty(PropertyName = "insurer")]
        public string Insurer { get; set; }
       

        // public ICollection<Product> Products { get; private set; }
    }
}
