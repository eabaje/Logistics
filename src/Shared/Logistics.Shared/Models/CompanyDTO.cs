using Logistics.Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;
// using Google.Cloud.Firestore;
// [JsonProperty.Json;

namespace Logistics.Shared.Models
{
   public  class CompanyDTO
    {
        // [JsonProperty(PropertyName = "companyId")]
        public int CompanyId { get; set; }

        // [JsonProperty(PropertyName = "uid")]
        public string Uid { get; set; }
      

        // [JsonProperty(PropertyName = "category")]
        public CompanyType Category { get; set; }

        // [JsonProperty(PropertyName = "companyName")]
        public string CompanyName { get; set; }

        // [JsonProperty(PropertyName = "contactTitle")]
        public string ContactTitle { get; set; }

       


        // [JsonProperty(PropertyName = "webSite")]
        public string WebSite { get; set; }

        // [JsonProperty(PropertyName = "allowSearch")]
        public bool AllowSearch { get; set; }

        // [JsonProperty(PropertyName = "loadId")]
        public string LastName { get; set; }

        // [JsonProperty(PropertyName = "loadId")]
        public string FirstName { get; set; }
        public string ContactName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
    }
}
