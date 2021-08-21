// [JsonProperty.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Logistics.Shared.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public abstract int EntityId { get; }
        // [JsonProperty(PropertyName = "createdBy")]
        public string CreatedBy { get; set; }

        // [JsonProperty(PropertyName = "createdOn")]
        public DateTime CreatedOn { get; set; }

        // [JsonProperty(PropertyName = "modifiedBy")]
        public string ModifiedBy { get; set; }

        // [JsonProperty(PropertyName = "modifiedOn")]
        public DateTime ModifiedOn { get; set; }

    }
    public abstract class BaseCompany
    {
        [Key]
        public abstract Guid EntityId { get; }
        // [JsonProperty(PropertyName = "createdBy")]
        public string CreatedBy { get; set; }

        // [JsonProperty(PropertyName = "createdOn")]
        public DateTime CreatedOn { get; set; }

        // [JsonProperty(PropertyName = "modifiedBy")]
        public string ModifiedBy { get; set; }

        // [JsonProperty(PropertyName = "modifiedOn")]
        public DateTime ModifiedOn { get; set; }

    }
    public abstract class BaseInfo
    {
        [Key]
        public abstract int EntityId { get; }

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

        // [JsonProperty(PropertyName = "fax")]
        public string Fax { get; set; }

        // [JsonProperty(PropertyName = "createdBy")]
        public string CreatedBy { get; set; }

        // [JsonProperty(PropertyName = "createdOn")]
        public DateTime CreatedOn { get; set; }

        // [JsonProperty(PropertyName = "modifiedBy")]
        public string ModifiedBy { get; set; }

        // [JsonProperty(PropertyName = "modifiedOn")]
        public DateTime ModifiedOn { get; set; }

    }
}
