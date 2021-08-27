using Logistics.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logistics.AdminUI.Services.Interfaces
{
   public  interface IShipperService
    {
      //  public Task<IEnumerable<ShipperDTO>> GetShippers();

      //  public Task<IEnumerable<ShipperDTO>> GetShippersByServiceType();
        public Task<ShipperDTO> GetShipperByServiceType(string SerrviceTypeId,string salonId=null);
        public Task<ShipperDTO> GetShipperBySalonServiceType(string SerrviceTypeId);
    }
}
