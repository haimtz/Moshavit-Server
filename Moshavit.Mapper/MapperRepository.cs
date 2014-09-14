using System;
using System.Collections.Generic;
using Moshavit.Entity;
using Moshavit.Entity.Dto;
using Moshavit.Entity.Dto.messages;
using Moshavit.Entity.TableEntity;

namespace Moshavit.Mapper
{
    public class MapperRepository : IMapperRepository
    {
        #region Private Members
        private readonly Dictionary<Type, Delegate> _mapperRepository = new Dictionary<Type, Delegate>(); 
        private readonly Dictionary<Type, Type> _typeToConverTypes = new Dictionary<Type, Type>();
        #endregion

        #region Constructor
        public MapperRepository()
        {
            Converts();
            RegisterTypes();
        }
        #endregion

        #region Private Method
        private void Converts()
        {
            _mapperRepository.Add(typeof(UserRegistertionData), new Func<UserRegistertionData, UserTable>(ConvertUserRegistration));
            _mapperRepository.Add(typeof(UserTable), new Func<UserTable, UserRegistertionData>(ConvertUserTableToUserRegistration));

            _mapperRepository.Add(typeof(BabySitterTable), new Func<BabySitterTable, BabySitterMessageDto>(ConvertUserBabysiterToDto));
            _mapperRepository.Add(typeof(BabySitterMessageDto), new Func<BabySitterMessageDto, BabySitterTable>(ConvertUserBabysiterToTable));
        }

        private BabySitterTable ConvertUserBabysiterToTable(BabySitterMessageDto message)
        {
            return new BabySitterTable
            {
                IdMessage = message.IdMessage,
                IdUser = message.IdUser,
                Title = message.Title,
                Content = message.Content,
                StartTime = message.StarTime,
                EndTime = message.EndTime,
                Rate = message.Rate
            };
        }

        private BabySitterMessageDto ConvertUserBabysiterToDto(BabySitterTable message)
        {
            return new BabySitterMessageDto
            {
                IdMessage = message.IdMessage,
                IdUser = message.IdUser,
                Title = message.Title,
                Content = message.Content,
                StarTime = message.StartTime,
                EndTime = message.EndTime,
                Rate = message.Rate
            };
        }

        private void RegisterTypes()
        {
            _typeToConverTypes.Add(typeof(UserRegistertionData), typeof(UserTable));
            _typeToConverTypes.Add(typeof(UserTable), typeof(UserRegistertionData));

            _typeToConverTypes.Add(typeof(BabySitterTable), typeof(BabySitterMessageDto));
        }
        #endregion

        #region Public Method
        public Func<T, TK> GetMapperFunction<T, TK>()
        {
            Delegate result;
            _mapperRepository.TryGetValue(typeof(T), out result);

            if (result == null)
            {
                throw new KeyNotFoundException(string.Format("The key type: {0} is invalid", typeof(T)));
            }
            return result as Func<T, TK>;
        }

        public Type TypeMapper(Type type)
        {
            Type result;
            _typeToConverTypes.TryGetValue(type, out result);

            if (result == null)
            {
                throw new KeyNotFoundException(string.Format("The key Type {0} is invalid", type));
            }
            return result;

        }
        #endregion

        #region Conversion 
        private UserTable ConvertUserRegistration(UserRegistertionData user)
        {
            return new UserTable
            {
                IdUser = user.IdUser,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                Email = user.Email,
                Phone = user.Phone,
                Password = user.Password,
                IsResident = user.IsResident,
                IsActive = user.IsActive,
                StartTime = user.StartTime,
                Token = ""
            };
        }
        private UserRegistertionData ConvertUserTableToUserRegistration(UserTable user)
        {
            return new UserRegistertionData
            {
                IdUser = user.IdUser,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address,
                Phone = user.Phone,
                Password = user.Password,
                StartTime = user.StartTime,
                IsActive = user.IsActive
            };
        }
        #endregion

    }
}
