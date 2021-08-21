using Logistics.Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
// using Google.Cloud.Firestore;
// [JsonProperty.Json;
using System.ComponentModel;

namespace Logistics.Shared.Models
{ 
    [FirestoreData]
   public class ConsignmentDTO
    {
        // [JsonProperty(PropertyName = "LoadId")]
        [Key]
        public Guid LoadId { get; set; }
        // [JsonProperty(PropertyName = "LoadCategory")]
        [DisplayName("Category")]
        public string LoadCategory { get; set; }

        [DisplayName("Date")]
        // [JsonProperty(PropertyName = "LoadDate")]
        public DateTime? LoadDate { get; set; }

        [DisplayName("Load Type")]
        // [JsonProperty(PropertyName = "LoadType")]
        public string LoadType { get; set; }

        [DisplayName("Weight")]
        // [JsonProperty(PropertyName = "LoadWeight")]
        public Decimal? LoadWeight { get; set; }

        // [JsonProperty(PropertyName = "LoadUnit")]
        [DisplayName("Unit")]
        public LoadUnit LoadUnit { get; set; }

        [DisplayName("Description")]
        // [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }
      
        [DisplayName("Company")]
        // [JsonProperty(PropertyName = "CompanyId")]
        public Guid CompanyId { get; set; }

        public string Company { get; set; }
    }
}
