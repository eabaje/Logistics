// [JsonProperty.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logistics.Shared.Models
{
    public partial class EmailTemplate : BaseEntity
    {
        // [JsonProperty(PropertyName = "insuranceId")]
        public int Id { get; set; }

        // [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        // [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        // [JsonProperty(PropertyName = "subject")]
        public string Subject { get; set; }

        // [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }

        // [JsonProperty(PropertyName = "instruction")]
        public string Instruction { get; set; }
        public override int EntityId => Id;
    }
}
