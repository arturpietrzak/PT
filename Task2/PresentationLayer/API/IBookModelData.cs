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
        int Book_Id { get; set; }
        string Name { get; set; }
        int Pages { get; set; }
        double Price { get; set; }
    }
}
