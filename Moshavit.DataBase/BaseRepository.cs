using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Moshavit.Entity;
using Moshavit.Mapper;

namespace Moshavit.DataBase
{
    public class BaseRepository<TTable,TDto> where TTable : class where TDto : class
    {
        private readonly IDataBase<TTable> _dataBase;
        private readonly IMapper _mapper;
        #region Constructor
        public BaseRepository(IDataBase<TTable> dataBase, IMapper mapper)
        {
            _dataBase = dataBase;
            _mapper = mapper;
        }
        #endregion

        #region Public/Protected method
        protected void Add(TTable entity)
        {
            _dataBase.Add(entity);
        }

        protected void Update(TDto entity)
        {
            var mapper = _mapper.Map<TDto, TTable>(entity);
            _dataBase.Update(mapper);
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
