using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
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
        protected virtual void Add(TDto entity)
        {
            var mapper = Mapper.Map(entity) as TTable;
            DataBase.Add(mapper);
        }

        virtual protected void Update(TDto entity)
        {
            var mapper = Mapper.Map(entity) as TTable;
            DataBase.Update(mapper);
        }

        virtual protected void Delete(int id)
        {
            throw new Exception("Not Implement yet");
        }

        virtual protected IEnumerable<TDto> GetAll()
        {
            var list = DataBase.GetAll().ToList();
            return Mapper.EnumerableMap<TTable, TDto>(list);
        }

        virtual protected IEnumerable<TDto> Were(Expression<Func<TDto,bool>>  predicate)
        {
            throw new Exception("Not Implement yet");
        }

        virtual protected TDto SelectFirst(Expression<Func<TTable, bool>> predicate)
        {
            var result = DataBase.FindBy(predicate).FirstOrDefault();
            var mapper = Mapper.Map(result) as TDto;

            return mapper;
        }
        #endregion
    }
}
