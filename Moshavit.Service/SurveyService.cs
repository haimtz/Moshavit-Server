using System;
using System.Collections.Generic;
using System.Linq;
using Moshavit.Const;
using Moshavit.DataBase;
using Moshavit.Entity;
using Moshavit.Entity.Dto;
using Moshavit.Entity.Interfaces;
using Moshavit.Exceptions;
using Moshavit.Mapper;

namespace Moshavit.Service
{
    public class SurveyService : BaseRepository<SurveyTable, SurveyDto>, ISurveyService
    {
        #region Members
        private readonly IUserService _userService;
        private readonly IVoteService _voteService;
        #endregion

        public SurveyService(IDataBase<SurveyTable> dataBase,
            IMapperType mapper,
            IUserService userService,
            IVoteService voteService)
            : base(dataBase, mapper)
        {
            _userService = userService;
            _voteService = voteService;
        }

        public void AddSurvey(SurveyDto survey)
        {
            var user = _userService.GetUser(survey.IdUser);
            if (user.Type != (int)UserType.Admin)
                throw new SurveyException("Only administrator allow to add Survey");

            if (survey.StartTime > survey.EndTime)
                throw new SurveyException("End time is earlier then Start time");

            if (IsraelTimeZone.Now() > survey.StartTime)
                throw new SurveyException("Start Time have pass already");

            base.Add(survey);
        }

        public void AddVote(UserVote vote)
        {
            var user = _userService.GetUser(vote.IdUser);
            var survey = GetSurvey(vote.IdSurvey);

            if(survey.EndTime < IsraelTimeZone.Now())
                throw new SurveyException("Voting has ended");

            if(user.Type > survey.TypeMember)
                throw new SurveyException("You not Allow to vote on this Survey");

            IsVoteLegal(vote);

            UpdateSurveyVote(survey, vote.Vote);
            _voteService.AddVote(survey.IdSurvey, vote.IdUser);
        }

        public void UpdateSurvey(SurveyDto survey)
        {
            var oldSurvey = GetSurvey(survey.IdSurvey);
            survey.Yes = oldSurvey.Yes;
            survey.No = oldSurvey.No;
            survey.Avoid = oldSurvey.Avoid;

            if (survey.TypeMember == 0)
                survey.TypeMember = oldSurvey.TypeMember;

            base.Update(survey);
        }

        public new IEnumerable<SurveyDto> GetAll()
        {
            var surveyList = base.GetAll().ToList();

            foreach (var surveyDto in surveyList)
            {
                var user = _userService.GetUser(surveyDto.IdUser) ?? _userService.GetUserArchive(surveyDto.IdUser);
                surveyDto.VadName = user.FirstName + " " + user.LastName;
            }

            return surveyList.OrderByDescending(s => s.StartTime);
        }

        public SurveyDto GetSurvey(int id)
        {
            var survey = base.SelectFirst(s => s.IdSurvey == id);
            var user = _userService.GetUser(survey.IdUser);

            survey.VadName = user.FirstName + " " + user.LastName;

            return survey;
        }

        public void DeleteSurvey(int id)
        {
            var survey = GetSurvey(id);
            base.Delete(survey);
            _voteService.DeleteVotes(id);
        }

        #region Private
        private void UpdateSurveyVote(SurveyDto survey, int vote)
        {
            switch ((Vote)vote)
            {
                case Vote.Yes:
                    survey.Yes++;
                    break;

                case Vote.No:
                    survey.No++;
                    break;

                case Vote.Avoid:
                    survey.Avoid++;
                    break;
            }

            base.Update(survey);
        }

        private bool IsVoteLegal(UserVote vote)
        {
            if (_voteService.IsUserVote(vote.IdSurvey, vote.IdUser))
                throw new VoteException("This User vote in this Survey");

            return true;
        }
        #endregion
    }
}
