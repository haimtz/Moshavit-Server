using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moshavit.Mapper;
using ReflectionTest;
using Rhino.Mocks;

namespace MapperTest
{
    [TestClass]
    public class MapperGetMapTest
    {
        private TypeMapper _mapper;
        private DummyA _dummyA;
        private DummyB _dummyB;
        private DummyC _dummyC;

        [TestInitialize]
        public void Setup()
        {
            var fakeRepository = MockRepository.GenerateStub<IMapperRepository>();
            _mapper = new TypeMapper(fakeRepository);
            _dummyA = new DummyA { Name = "dummy A", Family = "family A", Age = 37 };
            _dummyB = new DummyB { Name = "dummy A", Family = "family A", Age = 37 };
            _dummyC = new DummyC { Name = "dummy A", Family = "family A", Address = null };
        }

        [TestMethod]
        public void MapBetweenTwoObject()
        {
            var actual = _mapper.Map<DummyA, DummyB>(_dummyA);
            var expected = _dummyB;

            Assert.IsTrue(Equal.IsEqualObject(actual,expected));
        }

        [TestMethod]
        public void MapBetweenToObjectPartialCommonVariable()
        {
            var actual = _mapper.Map<DummyA, DummyC>(_dummyA);
            var expected = _dummyC;

            Assert.AreEqual(expected.GetType(), actual.GetType());
            Assert.IsTrue(Equal.IsEqualObject(actual, expected));
        }

        [TestMethod]
        public void MapFromSmallObjectToBig()
        {
            _dummyA.Age = 0;
            var expeted = _dummyA;
            var actual = _mapper.Map<DummyC, DummyA>(_dummyC);

            Assert.IsTrue(Equal.IsEqualObject(actual, expeted));
        }
    }
}
