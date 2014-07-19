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
        public UserService(IDataBase<UserTable> dataBase, IMapperType mapper) 
            : base(dataBase, mapper)
        {
        }

        /// <summary>
        /// Add new user to database
        /// </summary>
        /// <param name="user">details of a new user</param>
        /// <returns>true if succeed</returns>
        public bool Register(UserRegistertionData user)
        {
            try
            {
                user.StartTime = DateTime.Now;
                base.Add(user);
            }
            catch (Exception ex)
            {
                throw;
            }

            return true;
        }
    }
}
