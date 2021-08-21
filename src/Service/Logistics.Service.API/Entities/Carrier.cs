using Logistics.Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Logistics.Service.API.Entities
{
    // FreightLogistics.Service.API
    public class Carrier : BaseCompany
    {

        [Key]
        public Guid CarrierId { get; set; }
        public override Guid EntityId => CarrierId;

        public int CompanyId { get; set; }
        public CarrierType CarrierType { get; set; }
        public FleetType FleetType { get; set; }
        public int FleetNumber { get; set; }
        public bool? Licensed { get; set; }

        ///  [ForeignKey(CompanyId)]

        public int? Rating { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
    }
}
