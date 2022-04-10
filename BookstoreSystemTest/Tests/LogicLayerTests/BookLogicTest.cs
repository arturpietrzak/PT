using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreSystem.Logic;
using BookstoreSystem.Logic.API;
using BookstoreSystem.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace BookstoreSystemTest.Logic
{
    [TestClass]
    public class BookLogicTest
    {
        private LogicLayerAPI logic;
        private DataService service;

        [TestInitialize]
        public void Startup()
        {
            logic = LogicLayerAPI.CreateLayer();
            service = new DataService(logic);
        }

        [TestMethod]
        public void TestAddBook()
        {
            // adding a book should add a new state also
            Assert.AreEqual(service.GetAllBooks().Count(), 0);
            service.AddBook(1, "Test book", 200, 30.99, Genre.scifi, 5);
            Assert.AreEqual(service.GetAllBooks().Count(), 1);
            Assert.AreEqual(service.GetBookStockById(1), 5);

            Assert.AreEqual(service.GetBookById(1).Name, "Test book");
            Assert.AreEqual(service.GetBookById(1).Pages, 200);

            // try adding same book again should throw exception
            Assert.ThrowsException<Exception>(() => service.AddBook(1, "Test book", 200, 30.99, Genre.scifi));
        }

        [TestMethod]
        public void TestDeleteBook()
        {
            service.AddBook(1, "Test book", 200, 30.99, Genre.scifi, 15);
            Assert.AreEqual(service.GetAllBooks().Count(), 1);
            Assert.AreEqual(service.GetBookStockById(1), 15);
            service.RemoveBook(1);
            Assert.AreEqual(service.GetAllBooks().Count(), 0);

            // Removing the same book twice should throw exception
            Assert.ThrowsException<Exception>(() => service.RemoveBook(1));

            // removing book should remove the state as well
            Assert.ThrowsException<Exception>(() => service.GetBookStockById(1));
        }

        [TestMethod]
        public void TestSetStockAmount()
        {
            service.AddBook(1, "Test book", 200, 30.99, Genre.scifi, 15);
            Assert.AreEqual(service.GetBookStockById(1), 15);

            service.SetBookStockById(1, 30);
            Assert.AreEqual(service.GetBookStockById(1), 30);
        }

        [TestMethod]
        public void TestSetStockAmountForNonExistingBook()
        {
            Assert.ThrowsException<Exception>(() => service.SetBookStockById(13, 10));
        }
    }
}
