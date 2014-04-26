using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Moshavit.DataBase;

namespace Moshavit.Entity
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        T GetById(int id);

        IQueryable<T> GetAll();

        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
    }
}
