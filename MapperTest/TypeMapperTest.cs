using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moshavit.Mapper;
using ReflectionTest;
using Rhino.Mocks;

namespace MapperTest
{
    [TestClass]
    public class TypeMapperTest
    {
        #region Members
        private TypeMapper _mapper;
        private IMapperRepository _repositoryMapper;
        private Func<DummyB, DummyA> _convert = ConvertTest;
        private DummyB _dummay;


        #endregion

        [TestInitialize]
        public void Init()
        {
            _dummay = new DummyB { Name = "dummy Name", Family = "dummy family", Age = 20 };
            _repositoryMapper = MockRepository.GenerateMock<IMapperRepository>();
            _mapper = new TypeMapper(_repositoryMapper);
        }

        [TestMethod]
        public void Map_ConvertTypeFrom()
        {
            _repositoryMapper.Stub(m => m.GetMapperFunction<DummyB, object>()).Return(_convert);
            var actual = _mapper.Map(_dummay) as DummyA;
            var expected = _dummay;

            Assert.IsNotNull(actual);
            Assert.AreEqual(actual.Name, expected.Name);
            Assert.AreEqual(actual.Family, expected.Family);
            Assert.AreEqual(actual.Age, expected.Age);
        }

        private static DummyA ConvertTest(DummyB dummy)
        {
            return new DummyA
            {
                Name = dummy.Name,
                Family = dummy.Family,
                Age = dummy.Age
            };
        }
    }
}
