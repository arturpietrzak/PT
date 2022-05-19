using System;
using DataLayer.API;

namespace DataLayer.Implementations
{
    internal class Book : IBook
    {
        private int id;
        private string name;
        private int pages;
        private double price;

        public Book(int _id, string _name, int _pages,
            double _price)
        {
            id = _id;
            name = _name;
            pages = _pages;
            price = _price;
        }

        public int Id { get { return id; } }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Pages
        {
            get { return pages; }
            set { pages = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
