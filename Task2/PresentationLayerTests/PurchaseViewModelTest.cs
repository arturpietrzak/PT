using Microsoft.VisualStudio.TestTools.UnitTesting;
using PresentationLayer.API;
using PresentationLayer.ViewModel;
using System;

namespace PresentationLayerTests
{
    [TestClass]
    public class PurchaseViewModelTest
    {
        PurchasesViewModel viewModel;
        RandomGenerator randomGenerator;
        [TestInitialize]
        public void Startup()
        {
            randomGenerator = new RandomGenerator();
            viewModel = new PurchasesViewModel(randomGenerator);
        }

        [TestMethod]
        public void TestCheckDetails()
        {
            Assert.AreEqual(viewModel.purchaseData.Count, 0);

            viewModel.detailId = "1b7f8128-da34-11ec-9d64-0242ac120002";
            viewModel.CheckDetailsCommand.Execute(this);

            Assert.AreEqual(viewModel.purchaseData.Count, 0);
        }

        [TestMethod]
        public void TestCheckDetailsIncorrectID()
        {
            viewModel.detailId = "aaaaaaaaaaaaaaaaaaa";

            viewModel.CheckDetailsCommand.Execute(this);

            Assert.AreEqual(viewModel.purchaseData.Count, 0);
            Assert.IsNotNull(viewModel.detailData);
        }
    }
}
