using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.API;
using PresentationLayer.API;

namespace PresentationLayer.API
{
    public class BookModel : IBookModel
    {
        public BookModel(IBookService service)
        {
            Service = service;
        }

        public ICollection<IBookModelData> GetAllBooks()
        {
            ICollection<IBookData> serviceData = Service.GetAllBooks();
            IList<IBookModelData> modelData = new List<IBookModelData>();

            foreach (var servDataElement in serviceData)
            {
                modelData.Add(Transform(servDataElement));
            }

            return modelData;
        }

        public IBookService Service { get; }

        public IBookModelData Transform(IBookData data)
        {
            if (data == null)
            {
                return null;
            }
            return new BookModelData(data.Book_Id, data.Name, data.Pages, data.Price);
        }

        public bool AddBook(int id, String name, int pages, double price)
        {
            return Service.AddBook(id, name, pages, price);
        }

        public bool UpdateBook(int id, String name, int pages, double price)
        {
            return Service.UpdateBook(id, name, pages, price);
        }

        public bool DeleteBook(int id)
        {
            return Service.DeleteBook(id);
        }
    }
}
