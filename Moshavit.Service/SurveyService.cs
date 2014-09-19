using System;
using System.Collections.Generic;
using System.Linq;
using Moshavit.Const;
using Moshavit.DataBase;
using Moshavit.Entity;
using Moshavit.Entity.Dto;
using Moshavit.Entity.Interfaces;
using Moshavit.Mapper;

namespace Moshavit.Service
{
    public class SurveyService :BaseRepository<SurveyTable, SurveyDto>, ISurveyService
    {
        #region Members
        private readonly IUserService _userService;
        private readonly IVoteService _voteService;
        #endregion

        public SurveyService(IDataBase<SurveyTable> dataBase, IMapperType mapper, IUserService userService, IVoteService voteService)
            : base(dataBase, mapper)
        {
            _userService = userService;
            _voteService = voteService;
        }

        public void AddSurvey(SurveyDto survey)
        {
            base.Add(survey);
        }

        public bool AddVote(UserVote vote)
        {
            if(_voteService.IsUserVote(vote.IdSurvey, vote.IdUser))
                throw new Exception("This User vote in this Survey");

            var survey = GetSurvey(vote.IdSurvey);
            UpdateSurveyVote(survey, vote.Vote);
        }

        public void UpdateSurvey(SurveyDto survey)
        {
            var oldSurvey = GetSurvey(survey.IdSurvey);
            survey.Yes = oldSurvey.Yes;
            survey.No = oldSurvey.No;
            survey.Avoid = oldSurvey.Avoid;

            base.Update(survey);
        }

        public new IEnumerable<SurveyDto> GetAll()
        {
            var surveyList = base.GetAll().ToList();

            foreach (var surveyDto in surveyList)
            {
                var user = _userService.GetUser(surveyDto.IdUser);
                surveyDto.VadName = user.FirstName + " " + user.LastName;
            }

            return surveyList;
        }

        public SurveyDto GetSurvey(int id)
        {
            var survey = base.SelectFirst(s => s.IdSurvey == id);
            var user = _userService.GetUser(survey.IdUser);

            survey.VadName = user.FirstName + " " + user.LastName;

            return survey;
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
        #endregion
    }
}
