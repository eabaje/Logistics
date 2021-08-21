using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Logistics.Persistence.Entities
{
   public class Broker: BaseCompany
    {
        [Key]
        public Guid BrokerId { get; set; }
        public override Guid EntityId => BrokerId;
       
        public bool? Certified { get; set; }
        public String Experience { get; set; }
        public String JobScope { get; set; }
        public string SecondaryEmail { get; set; }

        [ForeignKey("CompanyId")]
        public string CompanyId { get; set; }
        public Company Company { get; set; }

    }
}
