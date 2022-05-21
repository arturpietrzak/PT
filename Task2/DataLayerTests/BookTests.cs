using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer.Implementations;

namespace DataLayerTests
{
    [TestClass]
    public class BookTests
    {
        private IDataLayerAPI dataLayer; 

        [TestInitialize]
        public void Startup()
        {
            dataLayer = IDataLayerAPI.CreateAPIUsingSQL();
        }

        [TestMethod]
        public void AddBookToDatabase()
        {

            Assert.IsTrue(dataLayer.CreateBook(321, "test book", 300, 20.99));
            Assert.AreEqual(dataLayer.GetBook(321).Name, "test book");
            Assert.AreEqual(dataLayer.GetBook(321).Pages, 300);
            Assert.AreEqual(dataLayer.GetBook(321).Price, 20.99);
        }

        [TestMethod]
        public void DeleteBookFromDatabase()
        {
            dataLayer.CreateBook(1, "test book", 200, 20.10);

            Assert.IsTrue(dataLayer.DeleteBook(dataLayer.GetBook(1).Id));
        }

        [TestMethod]
        public void UpdateBookInDatabase()
        {
            dataLayer.CreateBook(1, "test book", 200, 20.10);

            Assert.IsTrue(dataLayer.UpdateBook(1, "test book", 100, 20.10));
            Assert.AreEqual(dataLayer.GetBook(1).Pages, 100);
        }


    }
}
