using BookstoreSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookstoreSystemTest.Generators;
using BookstoreSystem.Data.API;

namespace BookstoreSystemTest.DataLayerTests
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

            IBook b = new TBook(656, "test book", 100, 50.99, Genre.thriller);
            ICustomer c = new TCustomer(100, "Test", "customer");
            IState s = new TState(b, 3);

            dataLayer.AddBook(b);
            dataLayer.AddCustomer(c);
            dataLayer.AddState(s);

            IEvent e = new TEventPurchase(s, c);
            dataLayer.AddEvent(e);
            Assert.AreEqual(dataLayer.AllEvents()[6].Customer.Name, "Test");
            Assert.AreSame(dataLayer.AllEvents()[6].Customer, c);
            Assert.AreEqual(dataLayer.AllEvents()[6].State.Amount, 3);
        }

        [TestMethod]
        public void TestEventDeletion()
        {
            dataLayer = generator.Generate();

            IBook b = new TBook(656, "test book", 100, 50.99, Genre.thriller);
            ICustomer c = new TCustomer(100, "Test", "customer");
            IState s = new TState(b, 3);

            dataLayer.AddBook(b);
            dataLayer.AddCustomer(c);
            dataLayer.AddState(s);

            IEvent e = new TEventPurchase(s, c);
            dataLayer.AddEvent(e);
            Assert.AreEqual(dataLayer.AllEvents()[6].Customer.Name, "Test");
            Assert.AreSame(dataLayer.AllEvents()[6].Customer, c);
            Assert.AreEqual(dataLayer.AllEvents()[6].State.Amount, 3);
        }
    }
}
