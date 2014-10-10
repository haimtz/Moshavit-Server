using System.Collections.Generic;
using Moshavit.Entity.Dto;
using Moshavit.Entity.Dto.Survey;

namespace Moshavit.Entity.Interfaces
{
    public interface ISurveyService
    {
        /// <summary>
        /// Add new survey to users
        /// </summary>
        /// <param name="survey"></param>
        void AddSurvey(SurveyDto survey);

        /// <summary>
        /// user vote
        /// </summary>
        /// <param name="vote"></param>
        /// <returns>true if vote accepted</returns>
        void AddVote(UserVote vote);

        /// <summary>
        /// Update single survey
        /// </summary>
        /// <param name="survey"></param>
        void UpdateSurvey(SurveyDto survey);

        /// <summary>
        /// delete survey from database
        /// </summary>
        /// <param name="id">survey id</param>
        void DeleteSurvey(int id);

        /// <summary>
        /// Get single survey
        /// </summary>
        /// <param name="id">survey id</param>
        /// <returns>DTO</returns>
        SurveyDto GetSurvey(int id);
        /// <summary>
        /// Get all Survey
        /// </summary>
        /// <returns></returns>
        IEnumerable<SurveyDto> GetAll();
    }
}
