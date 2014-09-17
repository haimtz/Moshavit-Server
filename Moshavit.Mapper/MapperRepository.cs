using System;
using System.Collections.Generic;
using Moshavit.Entity;
using Moshavit.Entity.Dto;
using Moshavit.Entity.Dto.messages;
using Moshavit.Entity.EntityTable;
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
            _mapperRepository.Add(typeof(CarpullMessageDto), new Func<CarpullMessageDto, CarPullTable>(ConvertUserCarpullToTable));
            _mapperRepository.Add(typeof(CarPullTable), new Func<CarPullTable, CarpullMessageDto>(ConvertUserCarpullToDto));

            _mapperRepository.Add(typeof(BulletinBoardTable), new Func<BulletinBoardTable, BulletinBoardDto>(ConvertBulltinBoardToDto));
            _mapperRepository.Add(typeof(BulletinBoardDto), new Func<BulletinBoardDto, BulletinBoardTable>(ConvertBulltinBoardToTable));

        }
        private void RegisterTypes()
        {
            _typeToConverTypes.Add(typeof(UserRegistertionData), typeof(UserTable));
            _typeToConverTypes.Add(typeof(UserTable), typeof(UserRegistertionData));
            _typeToConverTypes.Add(typeof(BabySitterTable), typeof(BabySitterMessageDto));
            _typeToConverTypes.Add(typeof(BabySitterMessageDto), typeof(BabySitterTable));
            _typeToConverTypes.Add(typeof(CarpullMessageDto), typeof(CarPullTable));
            _typeToConverTypes.Add(typeof(CarPullTable), typeof(CarpullMessageDto));
            _typeToConverTypes.Add(typeof(BulletinBoardTable), typeof(BulletinBoardDto));
            _typeToConverTypes.Add(typeof(BulletinBoardDto), typeof(BulletinBoardTable));
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

        private BabySitterTable ConvertUserBabysiterToTable(BabySitterMessageDto message)
        {
            return new BabySitterTable
            {
                IdMessage = message.IdMessage,
                IdUser = message.IdUser,
                Title = message.Title,
                Content = message.Content,
                StartTime = message.StartTime,
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
                StartTime = message.StartTime,
                EndTime = message.EndTime,
                Rate = message.Rate
            };
        }

        private CarPullTable ConvertUserCarpullToTable(CarpullMessageDto message)
        {
            return new CarPullTable
            {
                IdMessage = message.IdMessage,
                IdUser = message.IdUser,
                Title = message.Title,
                Content = message.Content,
                From = message.From,
                To = message.To,
                PickUp = message.PickUp,
                ReturnTime = message.ReturnTime
            };
        }

        private CarpullMessageDto ConvertUserCarpullToDto(CarPullTable message)
        {
            return new CarpullMessageDto
            {
                IdMessage = message.IdMessage,
                IdUser = message.IdUser,
                Title = message.Title,
                Content = message.Content,
                From = message.From,
                To = message.To,
                PickUp = message.PickUp,
                ReturnTime = message.ReturnTime
            };
        }

        private BulletinBoardDto ConvertBulltinBoardToDto(BulletinBoardTable message)
        {
            return new BulletinBoardDto
            {
                IdMessage = message.IdMessage,
                IdUser = message.IdUser,
                Title = message.Title,
                Content = message.Content,
                Description = message.Description,
                Details = message.Details
            };
        }

        private BulletinBoardTable ConvertBulltinBoardToTable(BulletinBoardDto message)
        {
            return new BulletinBoardTable
            {
                IdMessage = message.IdMessage,
                IdUser = message.IdUser,
                Title = message.Title,
                Content = message.Content,
                Description = message.Description,
                Details = message.Details
            };
        }
        #endregion

    }
}
