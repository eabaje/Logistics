using Logistics.Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logistics.Shared.Models
{
    public class VehicleDTO
    {

        public Guid VehicleId { get; set; }
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
        //   public FreightCarrier Dispatch { get; set; }
    }

}
