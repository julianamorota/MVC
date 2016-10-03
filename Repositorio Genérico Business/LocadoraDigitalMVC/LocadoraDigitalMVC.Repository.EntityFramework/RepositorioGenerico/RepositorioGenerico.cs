using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDigitalMVC.IRepository.RepositorioGenerico;
using LocadoraDigitalMVC.Repository.EntityFramework.Context;
using System.Data.Entity;
using System.Linq.Expressions;

namespace LocadoraDigitalMVC.Repository.EntityFramework.RepositorioGenerico
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
    {
        //LocadoraDigitalMVCContext context = new LocadoraDigitalMVCContext();

        //private LocadoraDigitalMVCContext context;
        //protected RepositorioGenerico()
        //{
        //    context = new LocadoraDigitalMVCContext();
        //}

        #region dependency injection
        private readonly LocadoraDigitalMVCContext context;
        public RepositorioGenerico(LocadoraDigitalMVCContext _context)
        {
            this.context = _context;
        }
        #endregion

        public T Get(int id)
        {
            return context.Set<T>().Find(id);
        }

        public T Create(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity;
        }

        public T Delete(T entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            context.Set<T>().Remove(entity);
            context.SaveChanges();
            return entity;
        }

        public IEnumerable<T> GetByFilter(Expression<Func<T, bool>> parametro)
        {
            return context.Set<T>().Where(parametro).ToList();
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().AsNoTracking().ToList();
        }
    }
}
