using System;
using BookstoreSystem;
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
            IBook book1 = new TBook(100, "Test book", 300, 10.99, Genre.poetry);
            IState state1 = new TState(book1, 1000);

            Assert.AreEqual(state1.Book, book1);
            Assert.AreEqual(state1.Amount, 1000);
        }

        [TestMethod]
        public void TestAddingState()
        {
            dataLayer = generator.Generate();

            IBook b = new TBook(100, "Test book", 300, 10.99, Genre.poetry);
            IState s = new TState(b, 1000);
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

            IBook b = new TBook(100, "Test book", 300, 10.99, Genre.poetry);
            IState s = new TState(b, 1000);
            dataLayer.AddState(s);
            Assert.AreEqual(s.Amount, 1000);
            dataLayer.GetStateByBook(b).Amount = 30;
            Assert.AreEqual(s.Amount, 30);
        }
    }
}
