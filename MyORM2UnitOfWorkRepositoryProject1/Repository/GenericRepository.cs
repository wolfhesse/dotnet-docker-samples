using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyORM2UnitOfWorkRepositoryProject1.Models;

namespace MyORM2UnitOfWorkRepositoryProject1.Repository
{
    /// <summary>
    /// 泛型的 Repository (提供各Repository繼承使用)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> 
        where T : class
    {
        private Model _context;


        private DbSet<T> table = null;

        public GenericRepository()
        {

        }

        public GenericRepository(Model context)
        {
            this._context = context;
            table = _context.Set<T>();
        }

        public IEnumerable<T> SelectAll()
        {
            return table.ToList();
        }

        public T SelvectById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
    }
}
