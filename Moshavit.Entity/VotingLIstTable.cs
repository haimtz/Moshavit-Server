using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moshavit.Entity
{
    /// <summary>
    /// List of users how vote
    /// </summary>
    [Table("VotedList")]
    public class VotingLIstTable
    {
        [Key]
        public int Id { get; set; }
        public int IdSurvey { get; set; }
        public int IdUser { get; set; }
        public DateTime VoteTime { get; set; }
    }
}
