using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Logistics.Service.API.Entities
{
   public class AssignVehicle
    {
        [Key]        
        public Guid AssignId { get; set; }
        public DateTime? AssignedDate { get; set; }
        public string Duration { get; set; }
        public string Purpose { get; set; }
        public string Comments { get; set; }
        public string DriverId { get; set; }
        public string VehicleId { get; set; }
        public Journey Journey { get; set; }
        public Vehicle Vehicle { get; set; }

    }
}
