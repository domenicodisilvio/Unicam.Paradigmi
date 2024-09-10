using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Modelli.Context;

namespace Unicam.Paradigmi.Modelli.Repositories
{
    public class GenericRepository <T> where T : class
    {
        protected MyDbContext _ctx;
        public GenericRepository(MyDbContext ctx)
        {
            _ctx = ctx;
        }
        public void Add(T entity)
        {
            _ctx.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
        }

        public void Modify(T entity)
        {
            _ctx.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(T entity) 
        {
            _ctx.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public T Get(object id)
        {
            return _ctx.Set<T>().Find(id);
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }
    }
}
