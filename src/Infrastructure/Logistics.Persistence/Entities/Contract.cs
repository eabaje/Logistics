using System;
using System.Collections.Generic;
using System.Text;

namespace Logistics.Persistence.Entities
{
   public  class Contract
    {

        public int ContractId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        //public byte[] Picture { get; set; }
    }
}
