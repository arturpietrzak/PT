using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.API
{
    internal class BookData : IBookData
    {
        public BookData(int book_Id, string name, int pages, double price)
        {
            Book_Id = book_Id;
            Name = name;
            Pages = pages;
            Price = price;
        }

        public int Book_Id { get; }
        public string Name { get; }
        public int Pages { get; }
        public double Price { get; }
    }
}
