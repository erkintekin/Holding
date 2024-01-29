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
        IQueryable<T> List {  get; }
        void Insert(T p);
        //T Get(Expression<Func<T, bool>> filter); // Silme işlemi yapmak için tek bir değer tutacak burada koşullu olarak tutacağı değer ID olacak
        void Delete(T p);
        void Update(T p);

        //List<T> List(Expression<Func<T, bool>> filter);

    }
}
