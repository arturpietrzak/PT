using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreSystem.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookstoreSystemTest.Generators;
using BookstoreSystem.Data.API;

namespace BookstoreSystemTest.DataLayerTests
{
    [TestClass]
    public class StateTest
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
        public void TestGetState()
        {
            Book book1 = new Book(100, "Test book", 300, 10.99, Genre.poetry);
            State state1 = new State(book1, 1000);

            Assert.AreEqual(state1.Book, book1);
            Assert.AreEqual(state1.Amount, 1000);
        }

        [TestMethod]
        public void TestAddingState()
        {
            dataLayer = generator.Generate();

            Book b = new Book(100, "Test book", 300, 10.99, Genre.poetry);
            State s = new State(b, 1000);
            dataLayer.AddState(s);

            Assert.AreEqual(dataLayer.GetStateByBook(b).Book, b);
            Assert.AreEqual(dataLayer.GetStateByBook(b).Amount, 1000);
        }

        [TestMethod]
        public void TestDeletingState()
        {
            dataLayer = generator.Generate();

            dataLayer.DeleteState(dataLayer.GetStateByBook(dataLayer.BookById(1)));
            Assert.ThrowsException<NullReferenceException>(() => dataLayer.GetStateByBook(dataLayer.BookById(1)).Amount);
        }

        [TestMethod]
        public void TestChangeState()
        {
            dataLayer = generator.Generate();

            Book b = new Book(100, "Test book", 300, 10.99, Genre.poetry);
            State s = new State(b, 1000);
            dataLayer.AddState(s);
            Assert.AreEqual(s.Amount, 1000);
            dataLayer.GetStateByBook(b).Amount = 30;
            Assert.AreEqual(s.Amount, 30);
        }
    }
}
