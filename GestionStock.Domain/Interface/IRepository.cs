using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Domain.Interface
{
    public interface IRepository<T>
    {
        T Add(T entity);
        T update(T entity);
        IEnumerable<T> All();
        T Get(int id);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void SaveChanges();
        void Delete(T entity);


    }
}
