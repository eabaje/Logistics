
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Logistics.Persistence.Entities
{
   
   
 

    public  class Journey:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public override int EntityId => Id;
        public int DriverId { get; set; }    
        public int VehicleId{ get; set; }
        public string JourneyStatus { get; set; }
        public string StartLocation { get; set; }
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string TotalDistance { get; set; }
        public string TravelTime { get; set; }
        public string RestTime { get; set; }
        public string ReportsTo { get; set; }
        public string Comment { get; set; }
        public VehicleDriver Driver { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
