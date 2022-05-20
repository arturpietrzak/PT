using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.API
{
    public interface IBookModelView
    {
        int Id { get; }
        String Name { get; set; }
        int Pages { get; set; }
        double Price { get; set; }
    }
}
