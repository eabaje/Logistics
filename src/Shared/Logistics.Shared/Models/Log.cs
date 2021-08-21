// [JsonProperty.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logistics.Shared.Models
{
    public partial class Log : BaseEntity
    {
        // [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        // [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }

        // [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        // [JsonProperty(PropertyName = "thread")]
        public string Thread { get; set; }

        // [JsonProperty(PropertyName = "level")]
        public string Level { get; set; }

        // [JsonProperty(PropertyName = "logger")]
        public string Logger { get; set; }

        // [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        // [JsonProperty(PropertyName = "exception")]
        public string Exception { get; set; }
        public override int EntityId => Id;
    }
}
