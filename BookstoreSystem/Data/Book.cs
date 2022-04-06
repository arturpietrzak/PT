using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreSystem.Data
{
    public class Book
    {
        private int id;
        private String name;
        private int pages;
        private double price;
        private Genre genre;

        public Book(int _id, string _name, int _pages,
            double _price, Genre _genre)
        {
            this.id = _id;
            this.name = _name;
            this.pages = _pages;
            this.price = _price;
            this.genre = _genre;
        }

        public int Id { get; }
        public String Name { get; set; }
        public int Pages { get; set; }
        public double Price { get; set; }
        public Genre Genre { get; set; }
    }

    public enum Genre
    {
        fantasy,
        romance,
        scifi,
        poetry,
        adventure,
        guide
    }
}
