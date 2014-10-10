using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moshavit.Entity.Dto;

namespace Moshavit.Entity.Interfaces
{
    public interface IVoteService
    {
        /// <summary>
        /// Add user vote to list of vote
        /// </summary>
        /// <param name="survey">id survey</param>
        /// <param name="user">id user</param>
        void AddVote(int survey, int user);

        /// <summary>
        /// Delete survey votes
        /// </summary>
        /// <param name="survey">survey votes to delete</param>
        void DeleteVotes(int survey);

        /// <summary>
        /// Check if user voted already
        /// </summary>
        /// <param name="survey">survey id</param>
        /// <param name="idUser">user id</param>
        /// <returns>true if user voted</returns>
        bool IsUserVote(int survey, int idUser);
    }
}
