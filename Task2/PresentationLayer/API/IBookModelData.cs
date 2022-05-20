using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.API;

namespace PresentationLayer.API
{
    public interface IBookModelData
    {
        IBookService Service{ get; }
        IEnumerable<IBookData> Book { get; }
        IBookModelView CreateBook(int book_id, String name, int pages, double price);
    }
}

