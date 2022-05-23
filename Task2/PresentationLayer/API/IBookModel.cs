using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.API;

namespace PresentationLayer.API
{
    public interface IBookModel
    {
        ICollection<IBookModelData> GetAllBooks();
        bool AddBook(int id, String name, int pages, double price);

        bool UpdateBook(int id, String name, int pages, double price);
        bool DeleteBook(int id);
    }
}

