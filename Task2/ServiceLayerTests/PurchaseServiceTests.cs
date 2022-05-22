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
            Assert.IsTrue(stateService.AddState(1, bookService.GetBookById(1).Book_Id, 10));
            var customerID = customerService.GetCustomerById(1).Customer_Id;
            var bookID = bookService.GetBookById(1).Book_Id;
            var stateID = stateService.GetStateByStateId(1).State_Id;

            Assert.IsTrue(!purchaseService.HandlePurchase(customerID, bookID, stateID));
        }

        [TestMethod]
        public void GetAllPurchasesByCustomerTest()
        {
            bookService.AddBook(1, "test book", 100, 30.12);
            customerService.AddCustomer(1, "Tom", "Black");
            stateService.AddState(1, customerService.GetCustomerById(1).Customer_Id, 10);
            stateService.AddState(2, customerService.GetCustomerById(1).Customer_Id, 30);


            purchaseService.HandlePurchase(customerService.GetCustomerById(1).Customer_Id, bookService.GetBookById(1).Book_Id, stateService.GetStateByStateId(1).State_Id);
            purchaseService.HandlePurchase(customerService.GetCustomerById(1).Customer_Id, bookService.GetBookById(1).Book_Id, stateService.GetStateByStateId(2).State_Id);
            //purchaseService.GetAllPurchasesByCustomer(customerService.GetCustomerById(1).Customer_Id);
            List<IPurchaseData> expected = new List<IPurchaseData>();
            expected.AddRange(purchaseService.GetAllPurchases().Where(e => e.Customer_id == 1).ToList());
            List<IPurchaseData> actual = new List<IPurchaseData> ();
            actual = purchaseService.GetAllPurchasesByCustomer(customerService.GetCustomerById(1).Customer_Id).ToList();
            //List<IEvent> events = dataLayer.GetAllEvents().ToList();
            List<IPurchaseData> purchaseDatas = new List<IPurchaseData>();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
