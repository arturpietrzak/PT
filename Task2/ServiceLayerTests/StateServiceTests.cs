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
        public IBookService bookService;
        public ICustomerService customerService;


        [TestInitialize]
        public void Startup()
        {
            stateService = IStateService.CreateTestAPI();
            bookService = IBookService.CreateTestAPI();
            customerService = ICustomerService.CreateTestAPI();
    }

        [TestMethod]
        public void AddStateToDatabaseTest()
        {
            Assert.IsTrue(bookService.AddBook(1, "test book", 200, 20.10));

            Assert.AreEqual(stateService.GetStateByStateId(1).State_Id, 1);
            Assert.AreEqual(stateService.GetStateByStateId(1).Book_Id, bookService.GetBookById(1).Book_Id);
            Assert.AreEqual(stateService.GetStateByStateId(1).Amount, 10);
        }

        [TestMethod]
        public void GetStateByBookIdTest()
        {

            bookService.AddBook(2, "test book", 200, 20.10);
            stateService.AddState(1, bookService.GetBookById(2).Book_Id, 10);

            Assert.AreEqual(stateService.GetStateByBookId(2).Book_Id, bookService.GetBookById(2).Book_Id);

        }

        [TestMethod]
        public void DeleteStateTest()
        {
            bookService.AddBook(1, "test book", 200, 20.10);
            stateService.AddState(1, bookService.GetBookById(1).Book_Id, 10);

            Assert.IsTrue(stateService.DeleteState(stateService.GetStateByStateId(1).State_Id));
        }

        [TestMethod]
        public void UpdateStateAmountTest()
        {
            bookService.AddBook(1, "test book", 200, 20.10);
            stateService.AddState(1, bookService.GetBookById(1).Book_Id, 10);

            Assert.IsTrue(stateService.UpdateStateAmount(stateService.GetStateByStateId(1).State_Id, 20));
            Assert.AreEqual(stateService.GetStateByStateId(1).Amount, 20);
        }
    }
}
