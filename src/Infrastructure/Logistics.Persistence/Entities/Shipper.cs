using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Logistics.Persistence.Entities
{
    public class Shipper:BaseCompany
    {
        [Key]
        public Guid ShipperId { get; set; }
        public override Guid EntityId => ShipperId;
       
        public int CompanyId { get; set; }
        public string ShipperName { get; set; }
        public string PackageType { get; set; }
        public string PackageName { get; set; }
        public DateTime? PackageDate { get; set; }
        public Company Company { get; set; }
    }
}
