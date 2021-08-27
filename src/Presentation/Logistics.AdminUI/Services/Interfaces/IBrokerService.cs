using Logistics.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logistics.AdminUI.Services.Interfaces
{

    public interface IBrokerService
    {

       
            public Task<IEnumerable<BrokerDTO>> GetBrokers();
            public Task<BrokerDTO> GetBrokerById(string Id);
            public Task<IEnumerable<BrokerDTO>> GetBrokersByDate(string fromdDateRange, string toDateRange);

            public Task<BrokerDTO> AddBroker(BrokerDTO BrokerDTO);

             //  public Task<SuccessModel> AddBroker(BrokerDTO BrokerDTO);

           public Task<SuccessModel> UpdateBroker(BrokerDTO BrokerDTO);

            public Task<SuccessModel> UpdateBrokerStatus(string BookId, BrokerDTO BrokerDTO);

            public Task Delete(string Id);

    }
}
