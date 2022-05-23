using Microsoft.VisualStudio.TestTools.UnitTesting;
using PresentationLayer.API;
using PresentationLayer.ViewModel;
using System;

namespace PresentationLayerTests
{
    [TestClass]
    public class CustomersViewModelTest
    {
        CustomersViewModel viewModel;
        RandomGenerator randomGenerator;
        [TestInitialize]
        public void Startup()
        {
            randomGenerator = new RandomGenerator();
            viewModel = new CustomersViewModel(randomGenerator);
        }

        [TestMethod]
        public void TestAddCustomer()
        {
            Assert.AreEqual(viewModel.customerData.Count, 10);

            viewModel.id = 111;
            viewModel.name = "Mandrzej";
            viewModel.surname = "Tandrzej";

            viewModel.AddCustomerCommand.Execute(this);

            Assert.AreEqual(viewModel.customerData.Count, 11);
        }

        [TestMethod]
        public void TestUpdateCustomer()
        {
            Assert.AreEqual(viewModel.customerData.Count, 10);

            viewModel.id = 1;
            viewModel.name = "Mandrzej";
            viewModel.surname = "Tandrzej";

            viewModel.UpdateCustomerCommand.Execute(this);

            Assert.AreEqual(viewModel.customerData.Count, 10);
        }

        [TestMethod]
        public void TestDeleteCustomer()
        {
            Assert.AreEqual(viewModel.customerData.Count, 10);

            viewModel.selectedId = 1;

            viewModel.DeleteCustomerCommand.Execute(this);

            Assert.AreEqual(viewModel.customerData.Count, 9);
        }

        [TestMethod]
        public void TestDeleteNonExistingCustomer()
        {
            Assert.AreEqual(viewModel.customerData.Count, 10);

            viewModel.selectedId = 1321321;

            viewModel.DeleteCustomerCommand.Execute(this);

            Assert.AreEqual(viewModel.customerData.Count, 10);
        }
    }
}
