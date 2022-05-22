using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.API;

namespace PresentationLayer
{
    internal class BookModelData : IBookModelData
    {
        public int Book_Id { get; }
        public string Name { get; }
        public int Pages { get; }
        public double Price { get; }

        public BookModelData(int book_Id, string name, int pages, double price)
        {
            Book_Id = book_Id;
            Name = name;
            Pages = pages;
            Price = price;
        }
    }
}
