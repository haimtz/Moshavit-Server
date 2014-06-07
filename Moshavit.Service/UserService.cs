using System;
using System.Collections.Generic;
using System.Linq;
using Moshavit.Entity;
using Moshavit.Entity.TableEntity;
using Moshavit.Exceptions;

namespace Moshavit.Service
{
    // TODO: change it to service
    public class UserService
    {
        #region Members
        private readonly IDataBase<UserTable> _repository;
        #endregion

        #region Constructor
        public UserService(IDataBase<UserTable> repository)
        {
            _repository = repository;
        }
        #endregion

        #region Public method
        /// <summary>
        /// Login Service to system
        /// </summary>
        /// <param name="username">string</param>
        /// <param name="password">string</param>
        /// <returns>Token</returns>
        public string Login(string username, string password)
        {
            //TODO:  if false throw exception
            var result = _repository.FindBy(x => x.Email == username && x.Password == password);

            var userTables = result as IList<UserTable> ?? result.ToList();
            if (!userTables.Any())
                throw new LoginException("Invalid user name or password");

            var user = userTables.First();

            return GenerateToken(user);
        }

        /// <summary>
        /// Create new user in the system
        /// </summary>
        /// <param name="user">New user</param>
        /// <returns>true if succeed</returns>
        public bool Register(UserTable user)
        {
            try
            {
                if (!IsEmailExist(user))
                    _repository.Add(user);
            }
            catch (Exception ex)
            {
                throw;
            }

            return true;
        }
        #endregion

        #region Private Method
        private bool IsEmailExist(UserTable user)
        {
            var result = _repository.FindBy(x => x.Email == user.Email);

            if(result.Any())
                throw new RegistrationException("This Email all ready existing");

            return false;
        }

        private string GenerateToken(UserTable user)
        {
            // create token
            var token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            user.Token = token;

            // save token in data base
            _repository.Update(user);

            return token;
        }

        #endregion
    }
}
