using System;
using System.ComponentModel.DataAnnotations.Schema;
using Moshavit.Entity.EntityTable;

namespace Moshavit.Entity
{
    [Table("BabySitter")]
    public class BabySitterTable : MessageTable
    {
        /// <summary>
        /// How mach cost one hour of babysitter
        /// </summary>
        public double Rate { get; set; }

        /// <summary>
        /// start time to work
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// estimate time to finish
        /// </summary>
        public DateTime EndTime { get; set; }
    }
}
