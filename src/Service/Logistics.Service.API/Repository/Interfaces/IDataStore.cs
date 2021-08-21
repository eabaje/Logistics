using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logistics.Service.API.Repository.Interfaces
{
    public  interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
      //  Task<bool> UpdateItemAsync(string id, T item);

        Task<bool> UpdateItemAsync( T item);
        Task<T> GetItemAsync(string id);

      //  Task<T> GetItemByCritriaAsync(Func<T, bool> query);
        Task<IEnumerable<T>> GetItemsAsync();
    

        Task<IEnumerable<T>> GetItemsByCritriaAsync(Func<T, bool> query);
        Task<bool> DeleteItemAsync(string id);

    }
}
