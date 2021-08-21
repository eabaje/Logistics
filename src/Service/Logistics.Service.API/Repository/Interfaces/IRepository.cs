using Microsoft.EntityFrameworkCore;
using System;
//using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Logistics.Service.API.Repository.Interfaces
{
 
    public interface IRepository<T> where T : class
    {
       Task<IEnumerable<T>> GetList();
       IQueryable<T> GetQueryable();
        IEnumerable<T> GetListOrdered(Expression<Func<T, int>> sortExpr);
        T Find(object id);
        Task Create(T obj);
        Task Delete(object id);
        Task Update(T obj);
        long Count();
        DbSet<T> Entities { get; }
        Task<int> SaveChangesAsync();

    }
}
