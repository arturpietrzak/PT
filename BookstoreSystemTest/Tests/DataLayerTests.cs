using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreSystem.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookstoreSystemTest.Generators;

namespace BookstoreSystemTest
{
    [TestClass]
    public class DataLayerTests

    {
        private DataContext dataContext;
        private DataRepository repository;

        [TestInitialize]
        public void Startup()
        { 
            dataContext = new DataContext();
            repository = new DataRepository();
        }

       [TestMethod]
        public void Equal()
        {
            Assert.AreEqual(dataContext.books.Count, 3+5+6);
            Assert.AreEqual(dataContext.customers, 3);
            Assert.AreEqual(dataContext.states, 3);
        }
    }
}
