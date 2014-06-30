using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moshavit.Mapper
{
    public interface IMapper
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
    }
}
