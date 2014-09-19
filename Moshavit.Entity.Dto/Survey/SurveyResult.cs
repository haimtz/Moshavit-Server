using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moshavit.Entity.Dto.Survey
{
    public class SurveyResult
    {
        public string Question { get; set; }
        public int Yes { get; set; }
        public int No { get; set; }
        public int Avoid { get; set; }
        public int Total
        {
            get { return Avoid + Yes + No; }
        }
    }
}
