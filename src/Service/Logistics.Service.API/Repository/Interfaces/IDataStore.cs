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
        Task<IEnumerable<T>> GetItemsAsync();
        Task<IEnumerable<T>> GetItemsByCritriaAsync(string criteria);
        Task<bool> DeleteItemAsync(string id);

    }
}
