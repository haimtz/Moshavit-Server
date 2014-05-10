using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moshavit.Entity.EntityTable
{
    [Table("BabySitter")]
    public class BabySitterTable : MessageTable
    {
        public double Rate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
