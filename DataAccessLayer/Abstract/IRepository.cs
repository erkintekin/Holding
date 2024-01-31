using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        void Create(T p);
        IQueryable<T> List { get; }
        void Update(T p);
        void Delete(T p);
    }
}
