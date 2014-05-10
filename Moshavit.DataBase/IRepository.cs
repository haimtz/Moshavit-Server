using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Moshavit.DataBase;

namespace Moshavit.Entity
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Add Entity to database
        /// </summary>
        /// <param name="entity">object</param>
        void Add(T entity);

        /// <summary>
        /// Update existing entity
        /// </summary>
        /// <param name="entity">object</param>
        void Update(T entity);

        /// <summary>
        /// Delete entity from database
        /// </summary>
        /// <param name="entity">object</param>
        void Delete(T entity);

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>object</returns>
        T GetById(int id);

        /// <summary>
        /// Get all T
        /// </summary>
        /// <returns>IQueryable</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Get all TK, implement T
        /// </summary>
        /// <typeparam name="TK">TK</typeparam>
        /// <returns>IQueryable</returns>
        IEnumerable<TK> GetAllByType<TK>() where TK : T;

        /// <summary>
        /// Get all T 
        /// </summary>
        /// <param name="predicate">query</param>
        /// <returns></returns>
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Get all TK, implement T
        /// </summary>
        /// <typeparam name="TK">TK</typeparam>
        /// <param name="predicate">query</param>
        /// <returns></returns>
        IEnumerable<TK> FindByType<TK>(Expression<Func<TK, bool>> predicate) where TK : T;
    }
}
