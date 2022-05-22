using DataLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.API
{
    public abstract class IBookService
    {
        // Create
        public abstract bool AddBook(int book_id, String name, int pages, double price);
        // Read
        public abstract ICollection<IBookData> GetAllBooks();
        public abstract ICollection<IBookData> GetAllBooksByTitle(string title); // multiple books can have the same name
        public abstract IBookData GetBookById(int id);
        // Update
        public abstract bool UpdateBook(int book_id, String name, int pages, double price);
        // Delete
        public abstract bool DeleteBook(int book_id);

        public static IBookService CreateAPI()
        {
            return new API(IDataLayerAPI.CreateAPIUsingSQL());
        }

        public static IBookService CreateTestAPI()
        {
            return new API(IDataLayerAPI.CreateTestAPI());
        }

        internal class API : IBookService
        {
            private IDataLayerAPI dataLayer;

            public API(IDataLayerAPI dataLayer)
            {
                this.dataLayer = dataLayer;
                dataLayer.Connect();
            }

            // Create
            public override bool AddBook(int book_id, String name, int pages, double price)
            {
                bool bookCreated = dataLayer.CreateBook(book_id, name, pages, price);
                if (!bookCreated)
                {
                    return false;
                }

                bool stateCreated = dataLayer.CreateState(book_id, dataLayer.GetBook(book_id), 0);
                if (!stateCreated)
                {
                    dataLayer.DeleteBook(book_id);
                    return false;
                }

                return true;
            }
            // Read
            public override ICollection<IBookData> GetAllBooks()
            {
                List<IBook> books = dataLayer.GetAllBooks().ToList();
                List<IBookData> bookDatas = new List<IBookData>();

                foreach (var book in books)
                {
                    bookDatas.Add(new BookData(book.Id, book.Name, book.Pages, book.Price));
                }

                return bookDatas;
            }
            public override ICollection<IBookData> GetAllBooksByTitle(string title)  // multiple books can have the same name
            {
                List<IBook> books = dataLayer.GetAllBooks().ToList();
                List<IBookData> bookDatas = new List<IBookData>();

                foreach (var book in books)
                {
                    if (book.Name == title)
                    {
                        bookDatas.Add(new BookData(book.Id, book.Name, book.Pages, book.Price));
                    }
                }

                return bookDatas;
            }
            public override IBookData GetBookById(int id)
            {
                IBook book = dataLayer.GetBook(id);

                if (book == null)
                {
                    return null;
                }

                return new BookData(book.Id, book.Name, book.Pages, book.Price);
            }
            // Update
            public override bool UpdateBook(int book_id, String name, int pages, double price)
            {
                return dataLayer.UpdateBook(book_id, name, pages, price);
            }
            // Delete
            public override bool DeleteBook(int book_id)
            {
                if (dataLayer.GetBook(book_id) == null)
                {
                    return false;
                }

                // Delete state
                int state_id = dataLayer.GetStateForBook(dataLayer.GetBook(book_id)).Id;                
                bool resultState = dataLayer.DeleteState(state_id);

                if (!resultState)
                {
                    return false;
                }

                // Delete book
                return dataLayer.DeleteBook(book_id);
            }
        }
    }
}
