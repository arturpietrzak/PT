using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.API;
using DataLayer.API;

namespace ServiceLayer.Implementations
{
    internal class BookService : IBookService
    {
        private IDataLayerAPI dataLayer;

        public BookService(IDataLayerAPI dataLayer)
        {
            this.dataLayer = dataLayer;
        }

        // Create
        public bool AddBook(int book_id, String name, int pages, double price)
        {
            return dataLayer.CreateBook(book_id, name, pages, price);
        }
        // Read
        public ICollection<IBookData> GetAllBooks()
        {
            List<IBook> books = dataLayer.GetAllBooks().ToList();
            List<IBookData> bookDatas = new List<IBookData>();

            foreach (var book in books)
            {
                bookDatas.Add(new BookData(book.Id, book.Name, book.Pages, book.Price));
            }

            return bookDatas;
        }
        public ICollection<IBookData> GetAllBooksByTitle(string title)  // multiple books can have the same name
        {
            List<IBook> books = dataLayer.GetAllBooks().ToList();
            List<IBookData> bookDatas = new List<IBookData>();

            foreach (var book in books)
            {
                if (book.Name == title) {
                    bookDatas.Add(new BookData(book.Id, book.Name, book.Pages, book.Price));
                }
            }

            return bookDatas;
        }
        public IBookData GetBookById(int id)
        {
            IBook book = dataLayer.GetBook(id);

            if (book == null)
            {
                return null;
            }

            return new BookData(book.Id, book.Name, book.Pages, book.Price);
        }
        // Update
        public bool UpdateBook(int book_id, String name, int pages, double price)
        {
            return dataLayer.UpdateBook(book_id, name, pages, price);
        }
        // Delete
        public bool DeleteBook(int book_id)
        {
            return dataLayer.DeleteBook(book_id);
        }
    }
}
