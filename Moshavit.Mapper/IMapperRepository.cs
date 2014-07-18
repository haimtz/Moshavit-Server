using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmitMapper.Mappers;

namespace Moshavit.Mapper
{
    public interface IMapperRepository
    {
        /// <summary>
        /// Get the function to convert type T to TK
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <typeparam name="TK">Type</typeparam>
        /// <returns>function to convert</returns>
        Func<T, TK> GetMapperFunction<T, TK>();

        /// <summary>
        /// Get the Type to convert from Type
        /// </summary>
        /// <param name="from">Type from to convert</param>
        /// <returns>Type to convert</returns>
        Type TypeMapper(Type from);

        
    }
}
