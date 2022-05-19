using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.API
{
    internal class IBookModelView
    {
        int Id { get; }
        string Name { get; set; }
        int Pages { get; set; }
        double Price { get; set; }
    }
}
