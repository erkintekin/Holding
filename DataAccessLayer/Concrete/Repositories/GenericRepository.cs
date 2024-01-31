using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly Context _context;    // Dependency Injection
        public GenericRepository(Context context)
        {
            _context = context;
        }
        public void Create(T p)
        {
            _context.Set<T>().Add(p);
        }
        IQueryable<T> IRepository<T>.List => _context.Set<T>().AsQueryable();
        public void Update(T p)
        {
            _context.Set<T>().Update(p);
        }
        public void Delete(T p)
        {
            _context.Set<T>().Remove(p);
        }
    }
}
