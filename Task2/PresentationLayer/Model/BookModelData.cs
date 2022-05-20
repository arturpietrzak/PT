using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.API;
using PresentationLayer.API;

namespace PresentationLayer
{
    public class BookModelData : IBookModelData
    {
        public BookModelData(IBookService service)
        {
            Service = service;
        }

        public IBookService Service { get; }

        public IEnumerable<IBookData> Book
        {
            get
            {
                IEnumerable<IBookData> books = Service.GetAllBooks();
                return books;
            }
        }

        IBookModelView IBookModelData.CreateBook(int book_id, string name, int pages, double price)
        {
            return null;//new BookModelView(book_id, name, pages, price);
        }
    }
}
