using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer.Implementations;

namespace DataLayerTests
{
    [TestClass]
    public class StateTests
    {
        private IDataLayerAPI dataLayer;

        [TestInitialize]
        public void Startup()
        {
            dataLayer = IDataLayerAPI.CreateTestAPI();
        }

        [TestMethod]
        public void AddStateToDatabase()
        {
            dataLayer.CreateBook(1, "test book", 200, 20.10);


            Assert.IsTrue(dataLayer.CreateState(1, dataLayer.GetBook(1), 10));
            Assert.AreEqual(dataLayer.GetState(1).Id, 1);
            Assert.AreEqual(dataLayer.GetState(1).Amount, 10);
            dataLayer = IDataLayerAPI.CreateTestAPI();
        }

        [TestMethod]
        public void GetStateForBookInDatabase()
        {

            dataLayer.CreateBook(1, "test book", 200, 20.10);
            dataLayer.CreateState(1, dataLayer.GetBook(1), 10);

            Assert.AreEqual(dataLayer.GetStateForBook(dataLayer.GetBook(1)), dataLayer.GetState(1));

        }

        [TestMethod]
        public void DeleteStateFromDatabase()
        {
            dataLayer.CreateBook(1, "test book", 200, 20.10);
            dataLayer.CreateState(1, dataLayer.GetBook(1), 10);

            Assert.IsTrue(dataLayer.DeleteState(dataLayer.GetState(1).Id));
        }

        [TestMethod]
        public void UpdateStateAmountInDatabase()
        {
            dataLayer.CreateBook(1, "test book", 200, 20.10);
            dataLayer.CreateState(1, dataLayer.GetBook(1), 10);

            Assert.IsTrue(dataLayer.UpdateStateAmount(dataLayer.GetState(1).Id, 20));
            Assert.AreEqual(dataLayer.GetState(1).Amount, 20);
        }
    }
}
