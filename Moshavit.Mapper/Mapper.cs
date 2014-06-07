using EmitMapper;

namespace Moshavit.Mapper
{
    public class Mapper : IMapper
    {
        public TTo Map<TFrom, TTo>(TFrom from) where TFrom : class where TTo : class
        {
            var mapper = GetMapper<TFrom, TTo>();

            return mapper.Map(from);
        }

        private ObjectsMapper<T, TK> GetMapper<T, TK>()
        {
            return ObjectMapperManager.DefaultInstance.GetMapper<T, TK>();
        }
    }
}
