using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Moshavit.Entity;

namespace Moshavit.DataBase
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private Context DbContext()
        {
            return new Context(); 
        }

        public virtual void Add(T entity)
        {
            using (var ctx = DbContext())
            {
                ctx.Set<T>().Add(entity);
                ctx.SaveChanges();
            }
        }

        public virtual void Update(T entity)
        {
            using (var ctx = DbContext())
            {
                ctx.Entry(entity).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }

        public virtual void Delete(T entity)
        {
            using (var ctx = DbContext())
            {
                ctx.Set<T>().Remove(entity);
            }
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            using (var ctx = DbContext())
            {
                var query = ctx.Set<T>();
                return query;
            }
        }

        public IQueryable<TK> GetAllByType<TK>()
        {
            using (var ctx = DbContext())
            {
                var query = ctx.Set<T>().OfType<TK>();
                return query;
            }
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            List<T> result;

            using (var ctx = DbContext())
            {
                var query = ctx.Set<T>().Where(predicate);
                result = query.ToList();
            }

            return result;
        }

        public IEnumerable<TK> FindByType<TK>(Expression<Func<TK, bool>> predicate)
        {
            List<TK> result;

            using (var ctx = DbContext())
            {
                var query = ctx.Set<T>().OfType<TK>().Where(predicate);
                result = query.ToList();
            }

            return result;
        }
    }
}
