using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.API;
using PresentationLayer.API;

namespace PresentationLayer.Model
{
    public class BookModelData : IBookModelData
    {

        public IBookService Service { get; }

        public BookModelData(IBookService service)
        {
            Service = service;
        }

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
            return new BookModelView(book_id, name, pages, price);
        }
    }
}
