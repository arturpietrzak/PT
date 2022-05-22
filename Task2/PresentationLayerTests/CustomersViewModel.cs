using Microsoft.VisualStudio.TestTools.UnitTesting;
using PresentationLayer.API;
using System;

namespace PresentationLayerTests
{
    [TestClass]
    public class CustomersViewModel
    {
        private INavigationModel model;
        [TestInitialize]
        public void Startup()
        {
            model = INavigationModel.testModel();
        }
    }
}
