using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Moshavit.Entity;

namespace Moshavit.DataBase
{
    public class BaseRepository<TTable,TDto> where TTable : class
    {
        private readonly IDataBase<TTable> _dataBase;

        #region Constructor
        public BaseRepository(IDataBase<TTable> dataBase)
        {
            _dataBase = dataBase;
        }
        #endregion

        #region Public/Protected method
        protected void Add(TDto entity)
        {
            throw new Exception("Not Implement yet");
        }

        protected void Update(int id)
        {
            throw new Exception("Not Implement yet");
        }

        protected void Delete(int id)
        {
            throw new Exception("Not Implement yet");
        }

        protected IEnumerable<TDto> GetAll()
        {
            throw new Exception("Not Implement yet");
        }

        protected IEnumerable<TDto> Were(Expression<Func<TDto,bool>>  predicate)
        {
            throw new Exception("Not Implement yet");
        }

        protected TDto SelectFirst(Expression<Func<TDto, bool>> predicate)
        {
            throw new Exception("Not Implement yet");
        }
        #endregion
    }
}
