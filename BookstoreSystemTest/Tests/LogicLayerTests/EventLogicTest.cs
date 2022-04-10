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
    public class EventLogicTest
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
        public void CustomerEventPurchaseTest()
        {
            service.AddCustomer(13, "Jonah", "Hill");
            service.AddBook(1, "Test book", 300, 20.59, Genre.scifi, 5);

            Assert.AreEqual(service.GetBookStockById(1), 5);
            service.SellBook(1, 13);
            Assert.AreEqual(service.GetBookStockById(1), 4);
        }

        [TestMethod]
        public void CustomerEventPurchaseWithNoInStockTest()
        {
            service.AddCustomer(13, "Jonah", "Hill");
            service.AddBook(1, "Test book", 300, 20.59, Genre.scifi, 0);

            // selling book with no in stock should throw exception
            Assert.ThrowsException<Exception>(() => service.SellBook(1, 13));
        }

        [TestMethod]
        public void CustomerEventReturnTest()
        {
            service.AddCustomer(13, "Jonah", "Hill");
            service.AddBook(3, "Test book", 300, 20.59, Genre.scifi, 3);
            Assert.AreEqual(service.GetBookStockById(3), 3);
            service.ReturnBook(3, 13);
            Assert.AreEqual(service.GetBookStockById(3), 4);
        }


    }
}
