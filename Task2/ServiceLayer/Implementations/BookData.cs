using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.API;

namespace ServiceLayer
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

        public override int Book_Id { get; }
        public override string Name { get; }
        public override int Pages { get; }
        public override double Price { get; }
    }
}
