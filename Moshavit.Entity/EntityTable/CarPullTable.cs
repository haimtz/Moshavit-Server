using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moshavit.Entity.EntityTable
{
    [Table("CarPull")]
    public class CarPullTable : MessageTable
    {
        public string From { get; set; }
        public string To { get; set; }
        public DateTime PickUp { get; set; }
        public DateTime ReturnTime { get; set; }
    }
}
