using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreSystem.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookstoreSystemTest.Generators;
using BookstoreSystem.Data.API;

namespace BookstoreSystemTest.Tests.DataLayerTests
{
    [TestClass]
    public class EventTest
    {
        private DataLayerAbstractAPI dataLayer = DataLayerAbstractAPI.CreateSimpleAPIImplementation();
        private DataLayerGenerator generator = new DataLayerGenerator();
        private RandomDataGenerator randomGenerator = new RandomDataGenerator();

        [TestInitialize]
        public void Startup()
        {
            dataLayer = DataLayerAbstractAPI.CreateSimpleAPIImplementation();
        }

        [TestMethod]
        public void TestEventAddition()
        {
            dataLayer = generator.Generate();

            Book b = new Book(656, "test book", 100, 50.99, Genre.thriller);
            Customer c = new Customer(100, "Test", "customer");
            State s = new State(b, 3);

            dataLayer.AddBook(b);
            dataLayer.AddCustomer(c);
            dataLayer.AddState(s);

            Event e = new EventPurchase(s, c);
            dataLayer.AddEvent(e);
            Assert.AreEqual(dataLayer.AllEvents()[6].Customer.Name, "Test");
            Assert.AreSame(dataLayer.AllEvents()[6].Customer, c);
            Assert.AreEqual(dataLayer.AllEvents()[6].State.Amount, 3);
        }

        [TestMethod]
        public void TestEventDeletion()
        {
            dataLayer = generator.Generate();

            Book b = new Book(656, "test book", 100, 50.99, Genre.thriller);
            Customer c = new Customer(100, "Test", "customer");
            State s = new State(b, 3);

            dataLayer.AddBook(b);
            dataLayer.AddCustomer(c);
            dataLayer.AddState(s);

            Event e = new EventPurchase(s, c);
            dataLayer.AddEvent(e);
            Assert.AreEqual(dataLayer.AllEvents()[6].Customer.Name, "Test");
            Assert.AreSame(dataLayer.AllEvents()[6].Customer, c);
            Assert.AreEqual(dataLayer.AllEvents()[6].State.Amount, 3);
        }
    }
}
