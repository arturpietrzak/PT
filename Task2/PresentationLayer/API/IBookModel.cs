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
        IBookModelData Transform(IBookData data);
        IBookService Service { get; }
        ICollection<IBookModelData> GetAllBooks();
    }
}

