using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
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
        public async Task Create(T p)
        {
            await _context.Set<T>().AddAsync(p);
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> List => _context.Set<T>().AsQueryable();

        public async Task Update(T p)
        {
            _context.Set<T>().Update(p);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T p)
        {
            _context.Set<T>().Remove(p);
            await _context.SaveChangesAsync();
        }
    }
}
