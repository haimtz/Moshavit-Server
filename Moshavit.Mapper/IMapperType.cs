using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmitMapper.Mappers;

namespace Moshavit.Mapper
{
    public interface IMapperType
    {
        /// <summary>
        /// Map object form TFrom to TTo
        /// </summary>
        /// <typeparam name="TFrom">object</typeparam>
        /// <typeparam name="TTo">object</typeparam>
        /// <param name="from">instance of TFrom</param>
        /// <returns>TTo</returns>
        TTo Map<TFrom, TTo>(TFrom from) where TFrom : class where TTo : class;

        /// <summary>
        /// Map IEnumerable TFrom to IEnumerable TTo  
        /// </summary>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="from"></param>
        /// <returns></returns>
        IEnumerable<TTo> EnumerableMap<TFrom, TTo>(IEnumerable<TFrom> from);

        /// <summary>
        /// Returns a mapper implementation instance for specified types
        /// </summary>
        /// <typeparam name="TFrom">Type from to convert</typeparam>
        /// <returns></returns>
        ObjectsMapperBaseImpl Map<TFrom>();

        /// <summary>
        /// Returns a mapper implementation instance for specified types
        /// </summary>
        /// <typeparam name="TFrom">Type</typeparam>
        /// <param name="from">instance of type to convert from</param>
        /// <returns>object of instance</returns>
        object Map<TFrom>(TFrom from);
    }
}
