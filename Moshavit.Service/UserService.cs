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
    public class UserService : BaseRepository<UserTable, UserRegistertionData>, IUserService
    {
        #region Constructor
        public UserService(IDataBase<UserTable> dataBase, IMapperType mapper)
            : base(dataBase, mapper)
        {
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Add new user to database
        /// </summary>
        /// <param name="user">details of a new user</param>
        /// <returns>true if succeed</returns>
        public bool Register(UserRegistertionData user)
        {
            var checkUser = base.SelectFirst(u => u.Email == user.Email);

            if (checkUser != null && checkUser.IsActive)
                throw new RegistrationException("User is exist");

            user.IsActive = true;
            user.StartTime = IsraelTimeZone.Now();
            user.Type = 3;

            if (checkUser != null && !checkUser.IsActive)
            {
                user.IdUser = checkUser.IdUser;
                UpdateUser(user);
                return true;
            }

            base.Add(user);

            return true;
        }

        public UserData Login(UserLoginDto userlogin)
        {
            var user = base.SelectFirst(x => x.Email == userlogin.Email
                && x.Password == userlogin.Password);

            
            if (user == null || !user.IsActive)
                throw new UserException("User don't exist");

            return ConvertToUserData(user);
        }

        public UserData GetUser(int id)
        {
            var user = base.SelectFirst(x => x.IdUser == id && x.IsActive);

            return ConvertToUserData(user);
        }

        public UserRegistertionData GetUser(string email)
        {
            var user = base.SelectFirst(u => u.Email == email && u.IsActive);

            return user;
        }

        public UserData GetUserArchive(int id)
        {
            var user = base.SelectFirst(u => u.IdUser == id);
            return ConvertToUserData(user);
        }

        public UserData UpdateUser(UserRegistertionData user)
        {
            var updateUser = base.SelectFirst(x => x.IdUser == user.IdUser);

            if (user.Password == null || user.Password.Trim() == string.Empty)
                user.Password = updateUser.Password;

            if (user.Email != updateUser.Email && GetUser(user.Email) != null)
                throw new UserException("This Email is Exist in the system");

            user.StartTime = updateUser.StartTime;
            user.IsActive = true;

            base.Update(user);
            updateUser = base.SelectFirst(x => x.IdUser == user.IdUser);

            return ConvertToUserData(updateUser);
        }

        public IEnumerable<UserData> GetAllUsers()
        {
            var userList = base.GetAll();

            return userList.Where(x => x.IsActive)
                .Select(ConvertToUserData)
                .ToList()
                .OrderByDescending(x => x.StartTime);
        }

        public void DeleteUser(int id)
        {
            var userToDelete = base.SelectFirst(x => x.IdUser == id);

            userToDelete.IsActive = false;
            base.Update(userToDelete);
        }
        #endregion

        #region Private Method

        private UserData ConvertToUserData(UserRegistertionData user)
        {
            if (user == null)
                return null;

            return new UserData
            {
                IdUser = user.IdUser,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address ?? string.Empty,
                Email = user.Email,
                Phone = user.Phone,
                StartTime = user.StartTime,
                Type = user.Type
            };
        }

        #endregion
    }
}
