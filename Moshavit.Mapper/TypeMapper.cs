using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using EmitMapper;
using EmitMapper.Mappers;
using EmitMapper.MappingConfiguration;

namespace Moshavit.Mapper
{
    public class TypeMapper : IMapperType
    {
        private readonly IMapperRepository _mapperRepository;

        #region Constructor
        public TypeMapper(IMapperRepository mapperRepository)
        {
            _mapperRepository = mapperRepository;
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Convert type TFrom to TTo
        /// </summary>
        /// <typeparam name="TFrom">Type</typeparam>
        /// <typeparam name="TTo">Type</typeparam>
        /// <param name="from">instance of TFrom</param>
        /// <returns>instance of TTo</returns>
        public TTo Map<TFrom, TTo>(TFrom from) where TFrom : class where TTo : class
        {
            var mapper = GetMapper<TFrom, TTo>();
            return mapper.Map(from);
        }

        public object Map<TFrom>(TFrom from)
        {
            var mapper = Map<TFrom>();
            return mapper.Map(from);
        }

        public ObjectsMapperBaseImpl Map<TFrom>()
        {
            var typeTo = _mapperRepository.TypeMapper(typeof (TFrom));
            var mapConfig = GetMApperConfig<TFrom, object>();

            return ObjectMapperManager.DefaultInstance.GetMapperImpl(typeof(TFrom), typeTo, mapConfig);
        }

        /// <summary>
        /// Convert IEnumerable collection from type TFrom to IEnumerable TTo
        /// </summary>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="from"></param>
        /// <returns></returns>
        public IEnumerable<TTo> EnumerableMap<TFrom, TTo>(IEnumerable<TFrom> from)
        {
            var mapper = GetMapper<TFrom, TTo>();
            return from.Select(mapper.Map);
        }
        #endregion

        #region Private Method
        /// <summary>
        /// Get two types and return object mapper manager
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TK"></typeparam>
        /// <returns>ObjectMapperManager</returns>
        private ObjectsMapper<T, TK> GetMapper<T, TK>()
        {
            return ObjectMapperManager.DefaultInstance.GetMapper<T, TK>();
        }

        private DefaultMapConfig GetMApperConfig<TFrom, TTo>()
        {
            var funcConvert = _mapperRepository.GetMapperFunction<TFrom, TTo>();

            return DefaultMapConfig.Instance.ConvertUsing(funcConvert);
        }
        #endregion
    }
}
