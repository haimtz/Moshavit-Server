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
            if (IsRegister(user.Email))
                throw new RegistrationException("The user is register");

            user.IsActive = false;
            user.StartTime = DateTime.Now;
            user.Type = 3;
            base.Add(user);

            return true;
        }

        public UserData Login(UserLoginDto userlogin)
        {
            var user = base.SelectFirst(x => x.Email == userlogin.Email
                && x.Password == userlogin.Password);

            // TODO: Check if user is active
            if (user == null)
                throw new Exception("User don't exist");

            return ConvertToUserData(user);
        }

        public UserData GetUser(int id)
        {
            var user = base.SelectFirst(x => x.IdUser == id);

            return ConvertToUserData(user);
        }
        
        public UserData UpdateUser(UserRegistertionData user)
        {
            var updateUser = base.SelectFirst(x => x.IdUser == user.IdUser);

            if (user.Password == null || user.Password.Trim() == string.Empty)
                user.Password = updateUser.Password;

            if (user.Email != updateUser.Email && IsRegister(user.Email))
                throw new Exception("This Email is Exist in the system");

            user.StartTime = updateUser.StartTime;
            base.Update(user);
            updateUser = base.SelectFirst(x => x.IdUser == user.IdUser);

            return ConvertToUserData(updateUser);
        }

        public IEnumerable<UserData> GetAllUsers()
        {
            var userList = base.GetAll();

            // TODO: return only active users
            return userList.Where(x => !x.IsActive)
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
        private bool IsRegister(string email)
        {
            var result = base.SelectFirst(x => x.Email == email);
            if (result != null)
                return true;

            return false;
        }

        private UserData ConvertToUserData(UserRegistertionData user)
        {
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
