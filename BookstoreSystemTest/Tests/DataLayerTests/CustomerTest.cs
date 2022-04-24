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
    public class CustomerTest
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
        public void TestGetCustomer()
        {
            ICustomer customer1 = new TCustomer(120, "Carl", "Monday");

            Assert.AreEqual(customer1.Id, 120);
            Assert.AreEqual(customer1.Name, "Carl");
            Assert.AreEqual(customer1.Surname, "Monday");

        }

        [TestMethod]
        public void TestCustomerAddition()
        {
            dataLayer = generator.Generate();

            dataLayer.AddCustomer(new TCustomer(141, "Andrei", "Deiu"));
            Assert.AreEqual(dataLayer.CustomerById(141).Name, "Andrei");

        }

        [TestMethod]
        public void TestCustomerDeletion()
        {
            dataLayer = generator.Generate();

            // deleted data should not be accessible
            dataLayer.DeleteCustomer(dataLayer.CustomerById(5));
            Assert.ThrowsException<NullReferenceException>(() => dataLayer.CustomerById(5).Id);

            dataLayer.DeleteCustomer(dataLayer.CustomerById(3));
            Assert.ThrowsException<NullReferenceException>(() => dataLayer.CustomerById(3).Name);
        }

        [TestMethod]
        public void TestChangeCustomer()
        {
            dataLayer = generator.Generate();

            dataLayer.AddCustomer(new TCustomer(141, "Lionel", "Messi"));
            Assert.AreEqual(dataLayer.CustomerById(141).Name, "Lionel");

            dataLayer.CustomerById(141).Name = "Krzysztof";
            Assert.AreEqual(dataLayer.CustomerById(141).Name, "Krzysztof");
            Assert.AreEqual(dataLayer.CustomerById(141).Surname, "Messi");
        }

        [TestMethod]
        public void TestCustomerOperationsWithRandomGeneratedData()
        {
            dataLayer = randomGenerator.Generate();

            dataLayer.AddCustomer(new TCustomer(514, "Jay", "Cutler"));
            Assert.AreEqual(dataLayer.CustomerById(514).Surname, "Cutler");
        }
    }
}
