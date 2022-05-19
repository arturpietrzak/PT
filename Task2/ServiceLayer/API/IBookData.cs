using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.API
{
    public interface IBookData
    {
        int Book_Id { get; }
        string Name { get; }
        int Pages { get; }
        double Price { get; }
    }
}
