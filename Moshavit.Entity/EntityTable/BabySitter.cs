using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moshavit.Entity.EntityTable
{
    class BabySitter : Message
    {
        public double Rate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EstimateTime { get; set; }
    }
}
