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
    }
}
