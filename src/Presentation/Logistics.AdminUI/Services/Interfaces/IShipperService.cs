using Logistics.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logistics.AdminUI.Services.Interfaces
{
   public  interface IPriceListService
    {
      //  public Task<IEnumerable<PriceListDTO>> GetPriceLists();

      //  public Task<IEnumerable<PriceListDTO>> GetPriceListsByServiceType();
        public Task<PriceListDTO> GetPriceListByServiceType(string SerrviceTypeId,string salonId=null);
        public Task<PriceListDTO> GetPriceListBySalonServiceType(string SerrviceTypeId);
    }
}
