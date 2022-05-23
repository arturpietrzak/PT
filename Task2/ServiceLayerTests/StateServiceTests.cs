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
    public class StateServiceTests
    {
        private IStateService stateService;
        public IBookService bookService;
        public ICustomerService customerService;


        [TestInitialize]
        public void Startup()
        {
            stateService = IStateService.CreateTestAPI();
            bookService = IBookService.CreateTestAPI();
            customerService = ICustomerService.CreateTestAPI();
    }

        [TestMethod]
        public void AddStateToDatabaseTest()
        {
            Assert.IsTrue(bookService.AddBook(1, "test book", 200, 20.10));
        }
    }
}
