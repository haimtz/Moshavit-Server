using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmitMapper.MappingConfiguration;

namespace Moshavit.Emit
{
    public class Emit
    {
        public Emit()
        {
            
        }

        public T GetMapByType<T>() where  T : class
        {
            return null;
        }

        public DefaultMapConfig GetConfig()
        {
            return new DefaultMapConfig();
        }
    }
}
