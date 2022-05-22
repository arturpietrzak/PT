using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer.API;


namespace DataLayerTests
{
    public class CustomerTests
    {
        private IDataLayerAPI dataLayer;

        [TestInitialize]
        public void Startup()
        {
            dataLayer = IDataLayerAPI.CreateAPIUsingSQL();
        }

        [TestMethod]
        public void AddCustomerToDatabase()
        {
            Assert.IsTrue(dataLayer.CreateCustomer(1,"Tom", "Black"));
            Assert.AreEqual(dataLayer.GetCustomer(1).Name, "Tom");
            Assert.AreEqual(dataLayer.GetCustomer(1).Surname, "Black");
        }

        [TestMethod]
        public void DeleteCustomerFromDatabase()
        {
            dataLayer.CreateCustomer(1, "Tom", "Black");

            Assert.IsTrue(dataLayer.DeleteCustomer(dataLayer.GetCustomer(1).Id));
        }

        [TestMethod]
        public void UpdateCustomerInDatabase()
        {
            dataLayer.CreateCustomer(1, "Tom", "Black");
            dataLayer.UpdateCustomer(1, "Carl", "Black");

            Assert.AreEqual(dataLayer.GetCustomer(1).Name, "Carl");

        }
    }
}
