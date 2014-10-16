using System.Collections.Generic;
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
        /// Get unactivated users 
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>user data</returns>
        UserData GetUserArchive(int id);
        /// <summary>
        /// Get user by the email
        /// </summary>
        /// <param name="email">user email</param>
        /// <returns>UserRegistertionData</returns>
        UserRegistertionData GetUser(string email);

        /// <summary>
        /// Update User details and Password
        /// </summary>
        /// <param name="user">new user details</param>
        /// <returns>UserData</returns>
        UserData UpdateUser(UserRegistertionData user);

        /// <summary>
        /// Remove user from system change his activity to false
        /// </summary>
        /// <param name="id">user identifier</param>
        void DeleteUser(int id);

        /// <summary>
        /// Get all user data
        /// </summary>
        /// <returns>UserData</returns>
        IEnumerable<UserData> GetAllUsers();

        
    }
}
