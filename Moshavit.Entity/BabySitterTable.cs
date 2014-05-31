using System;
using System.ComponentModel.DataAnnotations.Schema;
using Moshavit.Entity.EntityTable;

namespace Moshavit.Entity
{
    [Table("BabySitter")]
    public class BabySitterTable : MessageTable
    {
        public double Rate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
