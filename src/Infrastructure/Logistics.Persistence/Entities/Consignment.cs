using Logistics.Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Logistics.Persistence.Entities
{
   public class Consignment:BaseEntity
    {
        [Key]
        public int LoadId { get; set; }
        public override int EntityId => LoadId;
        public string LoadCategory { get; set; }
        public string LoadType { get; set; }
        public Decimal? LoadWeight { get; set; }
        public LoadUnit LoadUnit { get; set; }
        public string Comment { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
