using System;

namespace Moshavit.Entity.Dto
{
    public class SurveyDto
    {
        public int IdSurvey { get; set; }
        public int IdUser { get; set; }
        public string VadName { get; set; }
        public string Question { get; set; }
        public int Yes { get; set; }
        public int No { get; set; }
        public int Avoid { get; set; }
        public int TotalVote
        {
            get { return Yes + No + Avoid; }
        }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
