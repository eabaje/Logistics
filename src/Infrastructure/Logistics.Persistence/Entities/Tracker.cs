using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Logistics.Persistence.Entities
{
   public  class Tracker:BaseEntity
    {
        [Key]
        public int TrackId { get; set; }
        public override int EntityId => TrackId;
        public int JourneyId { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public DateTime TrackDate { get; set; }
        public Journey Journey { get; set; }
    }
}
