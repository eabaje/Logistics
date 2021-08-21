// [JsonProperty.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logistics.Shared.Models
{
   public class WalletDTO
    {
        // [JsonProperty(PropertyName = "uid")]
        public string Uid { get; set; }

        // [JsonProperty(PropertyName = "Ref")]
        public string Ref { get; set; }

        // [JsonProperty(PropertyName = "Date")]
        public DateTime Date { get; set; }

        // [JsonProperty(PropertyName = "Amount")]
        public string Amount { get; set; }

        // [JsonProperty(PropertyName = "Status")]

        public string Status { get; set; }
    }
}
