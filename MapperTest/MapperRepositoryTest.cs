using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moshavit.Entity.Dto;
using Moshavit.Entity.TableEntity;
using Moshavit.Mapper;

namespace MapperTest
{
    [TestClass]
    public class MapperRepositoryTest
    {
        private MapperRepository _mapper;
        [TestInitialize]
        public void Init()
        {
            _mapper = new MapperRepository();
        }

        [TestMethod]
        public void TypeMapper_GetType_AndReturnValidAnswer()
        {
            var actual = _mapper.TypeMapper(typeof (UserRegistertionData));
            var expected = new UserTable().GetType();

            Assert.IsTrue(actual.Name == expected.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TypeMapper_GetInvalidType()
        {
            _mapper.TypeMapper(typeof(DummyA));
        }

        [TestMethod]
        public void GetMapperFunction_GetValidType()
        {
            var actual = _mapper.GetMapperFunction<UserRegistertionData, UserTable>();
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void GetMapperFunction_GetInvalidType_Exception()
        {
            _mapper.GetMapperFunction<DummyA, UserRegistertionData>();
        }
    }
}
