using Logistics.Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Logistics.Service.API.Entities
{
    public class Vehicle:BaseCompany
    {
        [Key]
        public Guid VehicleId { get; set; }
        public override Guid EntityId => VehicleId;
        public string CarrierId { get; set; }
        public VehicleType VehicleType { get; set; }
        public string VehicleNumber { get; set; }
        public string SerialNumber { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleColor { get; set; }
        public string VehicleModel { get; set; }
        public string LicensePlate { get; set; }
        public System.DateTime? VehicleModelYear { get; set; }
        public System.DateTime? PurchaseYear { get; set; }
        public virtual Carrier Carrier { get; set; }
    }
}
