using System;
using System.Linq;
using Moshavit.Entity;
using Moshavit.Exceptions;

namespace Moshavit.Service
{
    // TODO: change it to service
    public class UserService
    {
        #region Members
        private readonly IRepository<User> _repository;
        #endregion

        #region Constructor
        public UserService(IRepository<User> repository)
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

            if (!result.Any())
                throw new LoginException("Invalid user name or password");

            var user = result.First();

            return GenerateToken(user);
        }

        /// <summary>
        /// Create new user in the system
        /// </summary>
        /// <param name="user">New user</param>
        /// <returns>true if succeed</returns>
        public bool Register(User user)
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
        private bool IsEmailExist(User user)
        {
            var result = _repository.FindBy(x => x.Email == user.Email);

            if(result.Any())
                throw new RegistrationException("This Email all ready existing");

            return false;
        }

        private string GenerateToken(User user)
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
