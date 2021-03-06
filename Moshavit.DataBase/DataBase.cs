﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using Moshavit.Entity;

namespace Moshavit.DataBase
{
    public class DataBase<T> : IDataBase<T> where T : class
    {
        
        protected Context DbContext()
        {
            var context = new Context();
            context.Configuration.LazyLoadingEnabled = false;
            return context;
        }

        public virtual void Add(T entity)
        {
            try
            {
                lock (this)
                {
                    using (var ctx = DbContext())
                    {

                        ctx.Set<T>().Add(entity);
                        ctx.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message + " Data base");
            }
            
            
        }

        public virtual void Update(T entity)
        {
            lock (this)
            {
                using (var ctx = DbContext())
                {
                    ctx.Entry(entity).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
        }

        public virtual void Delete(T entity)
        {
            lock (this)
            {
                using (var ctx = DbContext())
                {
                    if(ctx.Entry(entity).State == EntityState.Detached)
                        ctx.Set<T>().Attach(entity);
                    ctx.Set<T>().Remove(entity);
                    ctx.SaveChanges();
                }
            }
        }

        public T GetById(int id)
        {
            T result;
            lock (this)
            {
                using (var ctx = DbContext())
                {
                    result = ctx.Set<T>().Find(id);
                }
            }
            return result;
        }

        public IEnumerable<T> GetAll()
        {
            List<T> result;

            lock (this)
            {
                using (var ctx = DbContext())
                {
                    var query = ctx.Set<T>();
                    result = query.ToList();
                } 
            }

            return result;
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            List<T> result;
            lock (this)
            {
                using (var ctx = DbContext())
                {
                    var query = ctx.Set<T>().Where(predicate);
                    result = query.ToList();
                }
            }
            return result;
        }
    }
}