using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class Generic_Repository<T> : IRepository<T> where T : class
    {
        private readonly Context _context;    // Dependency Injection

        public Generic_Repository(Context context) 
        {
            _context = context;
        }

        IQueryable<T> IRepository<T>.List => _context.Set<T>().AsQueryable();

        public void Delete(T p)
        {
            _context.Set<T>().Remove(p);
        }

        public void Insert(T p)
        {
            _context.Set<T>().Add(p);
        }

        public List<T> List()
        {
            return _context.Set<T>().ToList();
        }

        //public T Get(Expression<Func<T, bool>> filter)
        //{
        //    return _context.Find
        //}

        //public List<T> List(Expression<Func<T, bool>> filter)
        //{
        //    throw new NotImplementedException();
        //}

        public void Update(T p)
        {
            _context.Set<T>().Update(p);
        }
    }
}
