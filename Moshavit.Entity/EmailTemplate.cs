using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moshavit.Entity
{
    [Table("EmailTemplate")]
    public class EmailTemplate
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Column("Content", TypeName = "ntext")]
        public string Content { get; set; }
    }
}
