using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moshavit.Entity.Dto
{
    /// <summary>
    /// represent the user vote
    /// </summary>
    public class UserVote
    {
        /// <summary>
        /// The survey of this vote
        /// </summary>
        public int IdSurvey { get; set; }

        /// <summary>
        /// The user how made the vote
        /// </summary>
        public int IdUser { get; set; }

        /// <summary>
        /// user vote yes = 1, no = 2, avoid = 3
        /// </summary>
        public int Vote { get; set; }
    }
}
