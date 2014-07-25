using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moshavit.Entity;
using Moshavit.Entity.Dto;
using Moshavit.Entity.TableEntity;
using Moshavit.Mapper;
using Moshavit.Service;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;
using ReflectionTest;

namespace Services
{
    [TestClass]
    public class UserServiceTest
    {
        private UserService _service;
        private IDataBase<UserTable> _dataBase;
        private IMapperType _mapper;

        [TestInitialize]
        public void Init()
        {
            _dataBase = MockRepository.GenerateMock<IDataBase<UserTable>>();
            _mapper = MockRepository.GenerateStub<IMapperType>();
            _service = new UserService(_dataBase, _mapper);
        }

        [TestMethod]
        public void Register_AddUser()
        {
            var user = new UserRegistertionData();
            _dataBase.Expect(x => x.Add(Arg<UserTable>.Is.Anything));
            _dataBase.Expect(s => s.FindBy(Arg<Expression<Func<UserTable, bool>>>.Is.Anything)).Return(new List<UserTable>());
            _service.Register(user);

        }

        [TestMethod]
        public void Login_UserExist()
        {
            var userTable = new UserTable();
            var login = new UserLoginDto
            {
                Email = "name@domain.com", Password = "1234"
            };

            _dataBase.Expect(x => x.FindBy(Arg<Expression<Func<UserTable, bool>>>.Is.Anything)).Return(new List<UserTable> { userTable  });
            _mapper.Stub(x => x.Map(userTable)).Return(new UserRegistertionData());
            var actual = _service.Login(login);

            Assert.AreEqual(actual.GetType(), typeof(UserData));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Login_UserNotExist()
        {
            var login = new UserLoginDto
            {
                Email = "name@domain.com",
                Password = "1234"
            };

            _dataBase.Expect(x => x.FindBy(Arg<Expression<Func<UserTable, bool>>>.Is.Anything)).Return(new List<UserTable> ());
            _mapper.Stub(x => x.Map(Arg<UserTable>.Is.Null)).Return(null);
            _service.Login(login);
        }
    }
}
