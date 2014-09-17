using System.ComponentModel.DataAnnotations.Schema;
using Moshavit.Entity.EntityTable;

namespace Moshavit.Entity
{
    [Table("BulletinBoard")]
    public class BulletinBoardTable : MessageTable
    {
        public string Description { get; set; }
        public string Details { get; set; }
    }
}
