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

        UserData Login(UserLoginDto userlogin);
    }
}
