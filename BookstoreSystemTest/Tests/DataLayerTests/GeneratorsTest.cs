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
    public class GeneratorsTest
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
        public void TestGeneratedData()
        {
            dataLayer = generator.Generate();

            Assert.AreEqual(dataLayer.BookById(1).Name, "The lord of the rings");
            Assert.AreEqual(dataLayer.BookById(10).Pages, 380);

            Assert.AreEqual(dataLayer.CustomerById(4).Surname, "Sienkiewicz");
            Assert.AreEqual(dataLayer.CustomerById(7).Name, "Johny");

            Assert.AreEqual(dataLayer.GetStateByBook(dataLayer.BookById(4)).Amount, 871);

            Assert.AreEqual(dataLayer.AllEvents().Count, 6);
        }

        [TestMethod]
        public void TestRandomlyGeneratedData()
        {
            dataLayer = randomGenerator.Generate();

            // check if generated data is in correct amounts
            Assert.AreEqual(dataLayer.AllBooks().Count, 10);
            Assert.AreEqual(dataLayer.AllCustomers().Count, 10);
            Assert.AreEqual(dataLayer.AllEvents().Count, 5);
        }
    }
}
