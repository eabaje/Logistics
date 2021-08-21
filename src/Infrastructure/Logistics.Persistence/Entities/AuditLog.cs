using System;
using System.Collections.Generic;
using System.Text;

namespace Logistics.Persistence.Entities
{
    public class AuditLog
    {

        public long Id { get; set; }
        public DateTime DateTime { get; set; }
        public String Username { get; set; }
       
        public String TableName { get; set; }
       
        public String Action { get; set; }

        public String KeyValues { get; set; }
        public String OldValues { get; set; }
        public String NewValues { get; set; }
    }

    public class AuditModel
    {
        public AuditModel()
        {
            Changes = new List<AuditDelta>();
        }
        public string UserName { get; set; }
        public string EventType { get; set; }
        public string DataType { get; set; }
        public string EventDate { get; set; }
        public string RecordID { get; set; }
        public string IPAddress { get; set; }
        public List<AuditDelta> Changes { get; set; }
    }

    public class AuditDelta
    {
        public string FieldName { get; set; }
        public string ValueBefore { get; set; }
        public string ValueAfter { get; set; }
    }
}

