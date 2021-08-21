// [JsonProperty.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Logistics.Shared.Models
{
    public partial class Setting : BaseEntity
    {
        // [JsonProperty(PropertyName = "id")]
        [Key]
        public int Id { get; set; }

        // [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        // [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
        public override int EntityId => Id;
    }
}
