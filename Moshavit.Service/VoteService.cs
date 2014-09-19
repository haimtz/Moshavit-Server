using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moshavit.Entity;
using Moshavit.Entity.Interfaces;

namespace Moshavit.Service
{
    public class VoteService : IVoteService
    {
        private readonly IDataBase<VotingLIstTable> _service;

        public VoteService(IDataBase<VotingLIstTable> service)
        {
            _service = service;
        }
        public void AddVote(int surveyId, int userId)
        {
            var userVote = new VotingLIstTable
            {
                IdSurvey = surveyId,
                IdUser = userId,
                VoteTime = DateTime.Now
            };

            _service.Add(userVote);
        }

        public bool IsUserVote(int surveyId, int userId)
        {
            var vote = _service.FindBy(v => v.IdSurvey == surveyId && v.IdUser == userId);

            return vote != null;
        }
    }
}
