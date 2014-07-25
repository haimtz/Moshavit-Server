using System;
using System.Collections.Generic;
using System.Linq;
using Moshavit.DataBase;
using Moshavit.Entity;
using Moshavit.Entity.Dto;
using Moshavit.Entity.TableEntity;
using Moshavit.Exceptions;
using Moshavit.Mapper;

namespace Moshavit.Service
{
    public interface IUserService
    {
        bool Register(UserRegistertionData user);
    }

    // TODO: change it to service
    public class UserService : BaseRepository<UserTable, UserRegistertionData>, IUserService
    {
        #region Constructor
        public UserService(IDataBase<UserTable> dataBase, IMapperType mapper)
            : base(dataBase, mapper)
        {
        }
        #endregion

        /// <summary>
        /// Add new user to database
        /// </summary>
        /// <param name="user">details of a new user</param>
        /// <returns>true if succeed</returns>
        public bool Register(UserRegistertionData user)
        {
            try
            {
                if (IsRegister(user))
                    throw new RegistrationException("The user is register");

                user.StartTime = DateTime.Now;
                base.Add(user);
            }
            catch (Exception ex)
            {
                throw;
            }

            return true;
        }

        public UserData Login(UserLoginDto userlogin)
        {
            var user = base.SelectFirst(x => x.Email == userlogin.Email
                && x.Password == userlogin.Password);

            if(user == null)
                throw new Exception("User don't exist");

            return new UserData
            {
                IdUser = user.IdUser,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                Email = user.Email,
                Phone = user.Phone
            };
        }

        #region Private Method
        private bool IsRegister(UserRegistertionData user)
        {
            var result = base.SelectFirst(x => x.Email == user.Email);
            if (result != null)
                return true;

            return false;
        }
        #endregion
    }
}
