using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moshavit.Entity.EntityTable
{
    [Table("Messages")]
    public abstract class  MessageTable
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
