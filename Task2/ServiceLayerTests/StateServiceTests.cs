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

        [TestInitialize]
        public void Startup()
        {
            stateService = IStateService.CreateTestAPI();
        }
    }
}
