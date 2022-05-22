using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ServiceLayerTests
{
    [TestClass]
    public class CustomerServiceTests
    {
        private ICustomerService customerService;

        [TestInitialize]
        public void Startup()
        {
            customerService = ICustomerService.CreateTestAPI();
        }

        [TestMethod]
        public void AddCustomerToDatabaseTest()
        {

            Assert.IsTrue(customerService.AddCustomer(1, "Tom", "Black"));
            Assert.AreEqual(customerService.GetCustomerById(1).Name, "Tom");
            Assert.AreEqual(customerService.GetCustomerById(1).Surname, "Black");
            Assert.AreEqual(customerService.GetCustomerById(1).Customer_Id, 1);

        }

        [TestMethod]
        public void DeleteCustomerFromDatabaseTest()
        {
            customerService.AddCustomer(1, "Tom", "Black");

            Assert.IsTrue(customerService.DeleteCustomer(1));
        }

        [TestMethod]
        public void UpdateCustomerInDatabaseTest()
        {
            customerService.AddCustomer(1, "Tom", "Black");

            Assert.IsTrue(customerService.UpdateCustomer(1, "Carl", "Black"));
            Assert.AreEqual(customerService.GetCustomerById(1).Name, "Carl");
        }
    }
}
