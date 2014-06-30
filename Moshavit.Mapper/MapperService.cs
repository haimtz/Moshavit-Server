using System;
using System.Collections.Generic;
using System.Linq;
using EmitMapper;

namespace Moshavit.Mapper
{
    public class MapperService : IMapper
    {
        public TTo Map<TFrom, TTo>(TFrom from) where TFrom : class where TTo : class
        {
            var mapper = GetMapper<TFrom, TTo>();

            return mapper.Map(from);
        }

        public IEnumerable<TTo> EnumerableMap<TFrom, TTo>(IEnumerable<TFrom> from)
        {
            var mapper = GetMapper<TFrom, TTo>();
            return from.Select(mapper.Map);
        }

        private ObjectsMapper<T, TK> GetMapper<T, TK>()
        {
            return ObjectMapperManager.DefaultInstance.GetMapper<T, TK>();
        }
    }
}
