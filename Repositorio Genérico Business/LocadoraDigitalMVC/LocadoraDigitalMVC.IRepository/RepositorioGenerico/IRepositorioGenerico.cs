using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDigitalMVC.IRepository.RepositorioGenerico
{
    public interface IRepositorioGenerico<T> where T : class
    {
        T Get(int id);
        T Create(T entity);
        T Update(T entity);
        T Delete(T entity);
        IEnumerable<T> GetByFilter(Expression<Func<T, bool>> parametro);
        IEnumerable<T> GetAll();
    }
}
