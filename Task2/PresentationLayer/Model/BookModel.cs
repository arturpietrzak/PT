using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.API;
using PresentationLayer.API;

namespace PresentationLayer
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
    }
}
