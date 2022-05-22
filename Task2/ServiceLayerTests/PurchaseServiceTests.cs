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
    public class PurchaseServiceTests
    {
        private IPurchaseService purchaseService;

        [TestInitialize]
        public void Startup()
        {
            purchaseService = IPurchaseService.CreateTestAPI();
        }
    }
}
