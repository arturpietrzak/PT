using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.API;

namespace PresentationLayer.Model
{
    internal class BookModelView : IBookModelView
    {
        int Id { get; }
        string Name { get; set; }
        int Pages { get; set; }
        double Price { get; set; }

        public BookModelView(int id, string name, int pages, double price)
        {
            Id = id;
            Name = name;
            Pages = pages;
            Price = price;
        }
    }
}
