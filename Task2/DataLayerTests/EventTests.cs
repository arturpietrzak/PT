using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer.API;

namespace DataLayerTests
{
    [TestClass]
    public class EventTests
    {
        private IDataLayerAPI dataLayer;

        [TestInitialize]
        public void Startup()
        {
            dataLayer = IDataLayerAPI.CreateAPIUsingSQL();
        }

        [TestMethod]
        public void AddEventToDatabase()
        {
            dataLayer.CreateCustomer(1, "Tom", "Black");
            dataLayer.CreateBook(1, "test book", 200, 20.10);
            dataLayer.CreateState(1, dataLayer.GetBook(1), 10);


            Assert.IsTrue(dataLayer.CreateEvent(dataLayer.GetState(1), dataLayer.GetCustomer(1)));
            Assert.AreEqual(dataLayer.GetState(1).Id, 1);
            Assert.AreEqual(dataLayer.GetState(1).Amount, 10);
        }

        [TestMethod]
        public void GetStateForStateInDatabase()
        {

            dataLayer.CreateCustomer(1, "Tom", "Black");
            dataLayer.CreateBook(1, "test book", 200, 20.10);
            dataLayer.CreateState(1, dataLayer.GetBook(1), 10);
            dataLayer.CreateEvent(dataLayer.GetState(1), dataLayer.GetCustomer(1));

          // to jest zle
            Assert.AreEqual(dataLayer.GetEventsForState(dataLayer.GetState(1)), dataLayer.GetState(1) );

        }

        [TestMethod]
        public void GetStateForCustomerInDatabase()
        {
            dataLayer.CreateCustomer(1, "Tom", "Black");
            dataLayer.CreateBook(1, "test book", 200, 20.10);
            dataLayer.CreateState(1, dataLayer.GetBook(1), 10);
            dataLayer.CreateState(2, dataLayer.GetBook(1), 20);
            dataLayer.CreateEvent(dataLayer.GetState(1), dataLayer.GetCustomer(1));
            dataLayer.CreateEvent(dataLayer.GetState(2), dataLayer.GetCustomer(1));

            List<IEvent> list = new List<IEvent>();


            //to tez
            Assert.AreEqual(dataLayer.GetEventsForCustomer(dataLayer.GetCustomer(1)), );
        }



    }
}
