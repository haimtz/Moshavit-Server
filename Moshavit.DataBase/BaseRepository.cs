using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Moshavit.Entity;
using Moshavit.Mapper;

namespace Moshavit.DataBase
{
    public class BaseRepository<TTable,TDto> where TTable : class where TDto : class
    {
        protected readonly IDataBase<TTable> DataBase;
        protected readonly IMapperType Mapper;
        #region Constructor
        public BaseRepository(IDataBase<TTable> dataBase, IMapperType mapper)
        {
            DataBase = dataBase;
            Mapper = mapper;
        }
        #endregion

        #region Public/Protected method
        virtual protected void Add(TDto entity)
        {
            var mapper = Mapper.Map<TDto, TTable>(entity);
            DataBase.Add(mapper);
        }

        virtual protected void Update(TDto entity)
        {
            var mapper = Mapper.Map<TDto, TTable>(entity);
            DataBase.Update(mapper);
        }

        virtual protected void Delete(int id)
        {
            throw new Exception("Not Implement yet");
        }

        virtual protected IEnumerable<TDto> GetAll()
        {
            throw new Exception("Not Implement yet");
        }

        virtual protected IEnumerable<TDto> Were(Expression<Func<TDto,bool>>  predicate)
        {
            throw new Exception("Not Implement yet");
        }

        virtual protected TDto SelectFirst(Expression<Func<TDto, bool>> predicate)
        {
            throw new Exception("Not Implement yet");
        }
        #endregion
    }
}
