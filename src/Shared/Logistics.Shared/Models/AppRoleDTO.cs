using System;
using Microsoft.AspNetCore.Identity;
// [JsonProperty.Json;

namespace Logistics.Shared.Models
{
    [Serializable, JsonObject]
    public class AppRoleDTO 
    {
        // [JsonProperty("Description")]
        public string Description { get; set; }
        // [JsonProperty("CreatedDated")]
        public DateTime CreatedDated { get; set; }
        // [JsonProperty("IPAddress")]
        public string IPAddress { get; set; }
    }
}
