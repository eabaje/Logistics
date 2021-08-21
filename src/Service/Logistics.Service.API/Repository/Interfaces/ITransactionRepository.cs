using System;

using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Logistics.Service.API.Entities;

namespace Logistics.Service.API.Repository.Interfaces
{
   public interface ITransactionRepository : IDataStore<Transaction>
    {

        Task<IEnumerable<Transaction>> GetTransactionByDate(string TransDate);


    }
}
