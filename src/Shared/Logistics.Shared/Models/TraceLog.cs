// [JsonProperty.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logistics.Shared.Models
{
    public partial class TraceLog : BaseEntity
    {
        // [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        // [JsonProperty(PropertyName = "controller")]
        public string Controller { get; set; }

        // [JsonProperty(PropertyName = "action")]
        public string Action { get; set; }

        // [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        // [JsonProperty(PropertyName = "performedOn")]
        public DateTime PerformedOn { get; set; }

        // [JsonProperty(PropertyName = "performedBy")]
        public string PerformedBy { get; set; }
        public override int EntityId => Id;
    }
}
