using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Logistics.Service.API.Entities
{
   public class Insurance:BaseInfo
    {



        [Key]
        public int InsuranceId { get; set; }
        public override int EntityId => InsuranceId;
        public string InsuranceName { get; set; }
        public string InsuranceType { get; set; }
        public string Insurer { get; set; }
       

        // public ICollection<Product> Products { get; private set; }
    }
}
