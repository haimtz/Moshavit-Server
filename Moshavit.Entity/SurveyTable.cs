using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moshavit.Entity
{
    [Table("Survey")]
    public class SurveyTable
    {
        [Key]
        public int IdSurvey { get; set; }
        public int IdUser { get; set; }
        public string Question { get; set; }
        public int Yes { get; set; }
        public int No { get; set; }
        public int Avoid { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsActive
        {
            get { return StartTime < EndTime; }
        }
    }
}
