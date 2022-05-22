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
    public class BookServiceTests
    {
        private IBookService bookService;

        [TestInitialize]
        public void Startup()
        {
            bookService = IBookService.CreateTestAPI();
        }

        [TestMethod]
        public void AddBookToDatabaseTest()
        {

            Assert.IsTrue(bookService.AddBook(1, "Book1", 100, 20.30));
            Assert.AreEqual(bookService.GetBookById(1).Name, "Book1");
            Assert.AreEqual(bookService.GetBookById(1).Book_Id, 1);
            Assert.AreEqual(bookService.GetBookById(1).Pages, 100);
            Assert.AreEqual(bookService.GetBookById(1).Price, 20.30);

        }

        [TestMethod]
        public void DeleteBookFromDatabaseTest()
        {
            bookService.AddBook(1, "Book1", 100, 20.30);

            Assert.IsTrue(bookService.DeleteBook(1));
        }

        [TestMethod]
        public void UpdateBookInDatabaseTest()
        {
            bookService.AddBook(1, "test book", 200, 20.10);

            Assert.IsTrue(bookService.UpdateBook(1, "test book", 100, 20.10));
            Assert.AreEqual(bookService.GetBookById(1).Pages, 100);
        }


    }
}
