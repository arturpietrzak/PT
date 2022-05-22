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
    public class BookServiceTests
    {
        private IBookService bookService;

        [TestInitialize]
        public void Startup()
        {
            bookService = IBookService.CreateTestAPI();
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
