using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moshavit.Entity.Dto;

namespace Moshavit.Service
{

    public interface IUserService
    {
        /// <summary>
        /// Add new user to the system
        /// </summary>
        /// <param name="user">new user</param>
        /// <returns>true if add succeed</returns>
        bool Register(UserRegistertionData user);

        /// <summary>
        /// Entrance existing user to system
        /// </summary>
        /// <param name="userlogin">entrance details</param>
        /// <returns>register user</returns>
        UserData Login(UserLoginDto userlogin);

        /// <summary>
        /// Get user by ID
        /// </summary>
        /// <param name="id">id of user</param>
        /// <returns>UserData</returns>
        UserData GetUser(int id);
 
        /// <summary>
        /// Get all user data
        /// </summary>
        /// <returns>UserData</returns>
        IEnumerable<UserData> GetAllUsers();
    }
}
