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
        private Context DbContext
        {
            get { return new Context(); }
        }

        public virtual bool Add(T entity)
        {
            using (var ctx = DbContext)
            {
                ctx.Set<T>().Add(entity);
                ctx.SaveChanges();
            }

            return true;
        }

        public virtual bool Update(T entity)
        {
            using (var ctx = DbContext)
            {
                ctx.Entry(entity).State = EntityState.Modified;
                ctx.SaveChanges();
            }

            return true;
        }

        public virtual bool Delete(T entity)
        {
            using (var ctx = DbContext)
            {
                ctx.Set<T>().Remove(entity);
            }

            return true;
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            using (var ctx = DbContext)
            {
                var query = ctx.Set<T>();
                return query;
            }
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            List<T> result;

            using (var ctx = DbContext)
            {
                var query = ctx.Set<T>().Where(predicate);
                result = query.ToList();
            }

            return result;
        }
    }
}
