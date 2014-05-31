using System;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moshavit.DataBase;
using Moshavit.Entity;
using Moshavit.Entity.TableEntity;
using Rhino.Mocks;

namespace BaseRepositoryTest
{
    [TestClass]
    public class SelectTest
    {
        private IDataBase<UserTable> _fakeData;

        [TestInitialize]
        
        public void Initialized()
        {
            
            var fakeData = MockRepository.GenerateStub<IDataBase<UserTable>>();
        }

        [TestMethod]
        
        public void TestMethod1()
        {
            var p = new Person();
            
            var r = p.Get(3);
        }
    }

    public class Person
    {
        public int Get(int n)
        {
            switch (n)
            {
                case 1:
                    return 10;
                case 2:
                    return 30;
                case 3:
                    return 20;
            }
        }
    }
}
