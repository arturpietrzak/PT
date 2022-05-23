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
        public IBookService bookService;
        public IStateService stateService;
        public ICustomerService customerService;

        [TestInitialize]
        public void Startup()
        {
            purchaseService = IPurchaseService.CreateTestAPI();
            bookService = IBookService.CreateTestAPI();
            stateService = IStateService.CreateTestAPI();
            customerService = ICustomerService.CreateTestAPI();
        }

        [TestMethod]
        public void HandlePurchaseTest()
        {
            Assert.IsTrue(bookService.AddBook(1, "test book", 100, 30.12));
            Assert.IsTrue(customerService.AddCustomer(1, "Tom", "Black"));
            var customerID = customerService.GetCustomerById(1).Customer_Id;
            var bookID = bookService.GetBookById(1).Book_Id;

            Assert.IsTrue(!purchaseService.HandlePurchase(customerID, bookID, 1));
        }

        [TestMethod]
        public void GetAllPurchasesByCustomerTest()
        {
            bookService.AddBook(1, "test book", 100, 30.12);
            customerService.AddCustomer(1, "Tom", "Black");
            stateService.AddState(1, customerService.GetCustomerById(1).Customer_Id, 10);
            stateService.AddState(2, customerService.GetCustomerById(1).Customer_Id, 30);


            Assert.IsFalse(purchaseService.HandlePurchase(1, 1, 1));
            Assert.IsFalse(purchaseService.HandlePurchase(1, 1, 2));

        }
    }
}
