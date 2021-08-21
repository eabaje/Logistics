// [JsonProperty.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logistics.Shared.Models
{
    public class AuditLog
    {
        // [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }
        // [JsonProperty(PropertyName = "auditDate")]
        public DateTime AuditDate { get; set; }

        // [JsonProperty(PropertyName = "username")]
        public String Username { get; set; }

        // [JsonProperty(PropertyName = "tableName")]
        public String TableName { get; set; }

        // [JsonProperty(PropertyName = "action")]
        public String Action { get; set; }

        // [JsonProperty(PropertyName = "keyValues")]
        public String KeyValues { get; set; }

        // [JsonProperty(PropertyName = "oldValues")]
        public String OldValues { get; set; }

        // [JsonProperty(PropertyName = "newValues")]
        public String NewValues { get; set; }
    }

    public class AuditModel
    {
        public AuditModel()
        {
            Changes = new List<AuditDelta>();
        }

        // [JsonProperty(PropertyName = "userName")]
        public string UserName { get; set; }

        // [JsonProperty(PropertyName = "eventType")]
        public string EventType { get; set; }

        // [JsonProperty(PropertyName = "dataType")]
        public string DataType { get; set; }

        // [JsonProperty(PropertyName = "eventDate")]
        public string EventDate { get; set; }

        // [JsonProperty(PropertyName = "recordID")]
        public string RecordID { get; set; }

        // [JsonProperty(PropertyName = "ipAddress")]
        public string IPAddress { get; set; }

        public List<AuditDelta> Changes { get; set; }
    }

    public class AuditDelta
    {
        // [JsonProperty(PropertyName = "fieldName")]
        public string FieldName { get; set; }

        // [JsonProperty(PropertyName = "valueBefore")]
        public string ValueBefore { get; set; }

        // [JsonProperty(PropertyName = "valueAfter")]
        public string ValueAfter { get; set; }
    }
}

