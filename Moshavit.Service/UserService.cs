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
    // TODO: change it to service
    public class UserService : BaseRepository<UserTable, UserRegister>
    {
        public UserService(IDataBase<UserTable> dataBase, IMapper mapper) 
            : base(dataBase, mapper)
        {
        }

        public bool Register(UserRegister user)
        {

            return true;
        }
    }
}
