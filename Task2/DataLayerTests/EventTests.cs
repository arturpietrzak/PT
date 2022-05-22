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
    public class EventTests
    {
        private IDataLayerAPI dataLayer;

        [TestInitialize]
        public void Startup()
        {
            dataLayer = IDataLayerAPI.CreateTestAPI();
        }
    

        [TestMethod]
        public void AddEventToDatabase()
        {
            dataLayer.CreateCustomer(1, "Tom", "Black");
            dataLayer.CreateBook(1, "test book", 200, 20.10);
            dataLayer.CreateState(1, dataLayer.GetBook(1), 10);


            Assert.IsTrue(dataLayer.CreateEvent(dataLayer.GetState(1), dataLayer.GetCustomer(1)));
        }

        [TestMethod]
        public void GetEventsForStateInDatabase()
        {
            dataLayer.CreateCustomer(1, "Tom", "Black");
            dataLayer.CreateCustomer(2, "Carl", "Smith");
            dataLayer.CreateBook(1, "test book", 200, 20.10);
            dataLayer.CreateState(1, dataLayer.GetBook(1), 10);
            dataLayer.CreateEvent(dataLayer.GetState(1), dataLayer.GetCustomer(1));
            dataLayer.CreateEvent(dataLayer.GetState(1), dataLayer.GetCustomer(2));

            List<IEvent> list = new List<IEvent>();
           // list.Add(dataLayer.GetEventById(dataLayer.GetEventById())
        }

    }
}
