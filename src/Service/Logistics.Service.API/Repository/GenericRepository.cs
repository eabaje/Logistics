
using Logistics.Service.API.Data;
using Logistics.Service.API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Logistics.Service.API.Repository
{
   

    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private LogisticsDbContext _context;
        private DbSet<T> table;
        private DbSet<T> _entities;
       // private DbSet<T> _entities;
        public GenericRepository(LogisticsDbContext context)
        {

            _context = context;
            table = _context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetList()
        {
            //  return  DynamicListSQL.convertList(table.ToList());
             return  await table.ToListAsync();
        }

        public IQueryable<T> GetQueryable()
        {         
             return  table.AsQueryable();
        }
        public IEnumerable<T> GetListOrdered(Expression<Func<T, Int32>> sortExpr)
        {

            return table.OrderByDescending(sortExpr).ToList();

        }
       
        public T Find(object id)
        {
            return table.Find(id);
        }

        public async Task Create(T obj)
        {
               table.Add(obj);

          await  _context.SaveChangesAsync();
        }
        public async Task<int> CreateAndReturnId(T obj)
        {
            table.Add(obj);

           int rt=  await _context.SaveChangesAsync();

            return rt;
        }
        public async Task Delete(object id)
        {
            T t = table.Find(id);
            table.Remove(t);
         await   _context.SaveChangesAsync();
        }


        public async Task Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
          await   _context.SaveChangesAsync();
        }

        public long Count()
        {
            return table.Count();

        }

       public virtual DbSet<T> Entities => _entities ?? (_entities = _context.Set<T>());


        public  async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();

            //try
            //{
            //    return await _context.SaveChangesAsync();
            //}
            //catch (DbEntityValidationException ex)
            //{
            //    var sb = new StringBuilder();

            //    foreach (var validationErrors in ex.EntityValidationErrors)
            //        foreach (var validationError in validationErrors.ValidationErrors)
            //            sb.AppendLine($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");

            //    throw new Exception(sb.ToString(), ex);
            //}
        }


    }
}
