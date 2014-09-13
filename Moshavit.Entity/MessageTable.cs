using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moshavit.Entity.TableEntity;

namespace Moshavit.Entity.EntityTable
{
    [Table("Messages")]
    public abstract class MessageTable
    {
        [Key]
        public int IdMessage { get; set; }
        public int IdUser { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        //[ForeignKey("IdUser")]
        //public virtual UserTable User { get; set; }
    }
}
