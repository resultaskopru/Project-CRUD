using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Repository
{
    public interface IRepository<T> where T:class
    {
        void Add(T entity);
        void Delete(T entity);
        T Get(int id);
        void Update(T entity);
        public IQueryable<T> GetAll(Expression<Func<T, bool>> condition);
        public IQueryable<T> GetAll();
    }
}
