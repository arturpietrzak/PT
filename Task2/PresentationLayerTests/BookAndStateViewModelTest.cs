using Microsoft.VisualStudio.TestTools.UnitTesting;
using PresentationLayer.API;
using PresentationLayer.ViewModel;
using System;

namespace PresentationLayerTests
{
    [TestClass]
    public class BookAndStateViewModelTest
    {
        BookAndStateViewModel viewModel;
        RandomGenerator randomGenerator;
        [TestInitialize]
        public void Startup()
        {
            randomGenerator = new RandomGenerator();
            viewModel = new BookAndStateViewModel(randomGenerator);
        }

        [TestMethod]
        public void TestPurchaseBook()
        {
            viewModel.purchaseBookId = 1;
            viewModel.purchaseCustomerId = 1;

            viewModel.PurchaseBookCommand.Execute(this);

            Assert.AreEqual(randomGenerator.GetCustomerModel().GetAllCustomers().Count, 10);
        }

        [TestMethod]
        public void TestGetState()
        {
            viewModel.detailId = 1;

            viewModel.CheckDetailsCommand.Execute(this);

            Assert.AreEqual(viewModel.stateData.Count, 0);
        }

        [TestMethod]
        public void TestDeleteBook()
        {
            viewModel.detailId = 1;
            randomGenerator.GetBookModel().DeleteBook(1);

            Assert.AreEqual(randomGenerator.GetBookModel().GetAllBooks().Count, 9);
        }
    }
}
