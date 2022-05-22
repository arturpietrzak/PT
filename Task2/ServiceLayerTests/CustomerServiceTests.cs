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
    }
}
