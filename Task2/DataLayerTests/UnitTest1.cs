using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataLayer.API;

namespace DataLayerTests
{
    [TestClass]
    public class DataLayerTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            IDataLayerAPI api = IDataLayerAPI.CreateAPIUsingSQL();
            api.Connect("Data Source=DESKTOP-KE9V009;Initial Catalog=BookstoreTest;Persist Security Info=True;User ID=bookstore;Password=123");
            api.CreateCustomer(3, "mariusz", "maciek");
            Assert.AreEqual(api.GetAllCustomers().Count, 1);
            api.ClearTables();
            Assert.AreEqual(api.GetAllCustomers().Count, 0);
        }
    }
}
