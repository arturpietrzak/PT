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

        public IEnumerable<IBookData> Books
        {
            get
            {
                IEnumerable<IBookData> books = Service.GetAllBooks();
                return books;
            }
        }
    }
}
