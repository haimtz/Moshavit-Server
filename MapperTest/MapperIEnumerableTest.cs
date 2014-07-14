using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moshavit.Mapper;
using ReflectionTest;
using Rhino.Mocks;

namespace MapperTest
{
    [TestClass]
    public class MapperIEnumerableTest
    {
        private TypeMapper _mapper;
        private IEnumerable<DummyA> _listDummyA;
        private IEnumerable<DummyB> _listDummyB;

        [TestInitialize]
        public void Setup()
        {
            var fakeRepository = MockRepository.GenerateStub<IMapperRepository>();
            _mapper = new TypeMapper(fakeRepository);
            _listDummyA = new List<DummyA>
            {
                new DummyA
                {
                    Name = "A",
                    Family = "A Family",
                    Age = 1
                },
                new DummyA
                {
                    Name = "A_A",
                    Family = "A_A Family",
                    Age = 10
                },new DummyA
                {
                    Name = "A_1",
                    Family = "A_1 Family",
                    Age = 15
                }
            };

            _listDummyB = new List<DummyB>
            {
                new DummyB
                {
                    Name = "A",
                    Family = "A Family",
                    Age = 1
                },
                new DummyB
                {
                    Name = "A_A",
                    Family = "A_A Family",
                    Age = 10
                },new DummyB
                {
                    Name = "A_1",
                    Family = "A_1 Family",
                    Age = 15
                }
            };
        }

        [TestMethod]
        public void IEnumerable_GetListAndConvertToList()
        {
            var actual = _mapper.EnumerableMap<DummyA, DummyB>(_listDummyA);
            var expected = _listDummyB;

            Assert.AreEqual(actual.Count(), expected.Count());
            Assert.IsTrue(Equal.IsEqual(actual, expected));
        }
    }
}
