using GestionStock.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly GestionStockContext _context;
        public Repository(GestionStockContext context)
        {
            _context = context;

        }
            
        public T Add(T entity)
        {
            return _context.Add(entity).Entity;
        }

        public IEnumerable<T> All()
        {
            return _context.Set<T>().AsQueryable().ToList();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsQueryable().Where(predicate).ToList();
        }

        public T Get(int id)
        {
            return _context.Find<T>(id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public T update(T entity)
        {
            return _context.Update(entity).Entity;
        }
    }
}
