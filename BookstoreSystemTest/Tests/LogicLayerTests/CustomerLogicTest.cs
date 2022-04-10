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
    public class CustomerLogicTest
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
        public void AddCustomerTest()
        {
            Assert.AreEqual(service.GetAllCustomers().Count(), 0);
            service.AddCustomer(15, "Piotr", "Borecki");
            Assert.AreEqual(service.GetAllCustomers().Count(), 1);
            Assert.AreEqual(service.GetCustomerById(15).Name, "Piotr");

            // Adding the same customer should throw exception
            Assert.ThrowsException<Exception>(() => service.AddCustomer(15, "Piotr", "Borecki"));
        }

        [TestMethod]
        public void DeleteCustomerTest()
        {
            Assert.AreEqual(service.GetAllCustomers().Count, 0);
            service.AddCustomer(13, "Adam", "Pokora");
            Assert.AreEqual(service.GetAllCustomers().Count, 1);
            Assert.AreEqual(service.GetCustomerById(13).Surname, "Pokora");
            service.RemoveCustomer(13);
            Assert.AreEqual(service.GetAllCustomers().Count, 0);

            // Deleting already deleted customer should throw exception
            Assert.ThrowsException<Exception>(() => service.RemoveCustomer(13));
        }
    }
}
