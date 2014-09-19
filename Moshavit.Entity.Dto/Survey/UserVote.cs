using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moshavit.Entity.Dto
{
    public class UserVote
    {
        public int IdSurvey { get; set; }
        public int IdUser { get; set; }
        /// <summary>
        /// user vote yes = 1, no = 2, avoid = 3
        /// </summary>
        public int Vote { get; set; }
    }
}
