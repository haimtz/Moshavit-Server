using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moshavit.Entity.Dto;
using Moshavit.Entity.TableEntity;

namespace Moshavit.EmitMapper
{
    public class EmitMapper
    {
        private readonly Dictionary<Type, Delegate> _mapper;

        #region Constructor
        public EmitMapper()
        {
            _mapper = new Dictionary<Type, Delegate>();
            InitailizedMapper();
        }
        #endregion

        #region Public Method
        public Dictionary<Type, Delegate> EmitDictionary
        {
            get { return _mapper; }
        }
        #endregion

        #region Private Method
        private void InitailizedMapper()
        {
            _mapper.Add(typeof(UserRegister), new Func<UserRegister, UserTable>(ConvertToUserTable));
        }

        private UserTable ConvertToUserTable(UserRegister user)
        {
            return new UserTable
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address,
                Phone = user.Phone,
                Password = user.Password
            };
        }
        #endregion
    }
}
