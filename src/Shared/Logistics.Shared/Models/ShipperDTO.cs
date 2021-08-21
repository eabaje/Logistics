// [JsonProperty.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Logistics.Shared.Models
{
    public class ShipperDTO
    {
        // [JsonProperty(PropertyName = "shipperId")]
      
      
        public Guid ShipperId { get; set; }
      

        // [JsonProperty(PropertyName = "companyId")]
        public int CompanyId { get; set; }

        // [JsonProperty(PropertyName = "shipperName")]
        public string ShipperName { get; set; }

        // [JsonProperty(PropertyName = "packageDate")]
        public DateTime? PackageDate { get; set; }

        // [JsonProperty(PropertyName = "packageType")]
        public string PackageType { get; set; }

        // [JsonProperty(PropertyName = "packageName")]
        public string PackageName { get; set; }

        // [JsonProperty(PropertyName = "company")]
        public string Company { get; set; }
    }
}
