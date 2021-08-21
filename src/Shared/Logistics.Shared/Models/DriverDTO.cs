// [JsonProperty.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Logistics.Shared.Models
{
   public class DriverDTO
    {
        // [JsonProperty(PropertyName = "driverId")]
        
        public int DriverId { get; set; }

        // [JsonProperty(PropertyName = "driverName")]
        public string DriverName { get; set; }

        // [JsonProperty(PropertyName = "driverLicense")]
        public string DriverLicense { get; set; }

        // [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        // [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        // [JsonProperty(PropertyName = "region")]
        public string Region { get; set; }

        // [JsonProperty(PropertyName = "postalCode")]
        public string PostalCode { get; set; }

        // [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        // [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }

        // [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        // [JsonProperty(PropertyName = "picture")]
        public string Picture { get; set; }

        // [JsonProperty(PropertyName = "company")]
        public string Company { get; set; }

        // public ICollection<Product> Products { get; private set; }
    }
}
