using System;
using System.Collections.Generic;
using Moshavit.Entity.Dto;
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
        }

        private void RegisterTypes()
        {
            _typeToConverTypes.Add(typeof(UserRegistertionData), typeof(UserTable));
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
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                Email = user.Email,
                Phone = user.Phone,
                Password = user.Password,
                IsResident = user.IsResident,
                IsActive = false,
                StartTime = user.StartTime,
                Token = ""
            };
        }
        #endregion

    }
}
