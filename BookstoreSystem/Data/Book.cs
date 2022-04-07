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
        private State state;

        public Book(int _id, string _name, int _pages,
            double _price, Genre _genre)
        {
            this.id = _id;
            this.name = _name;
            this.pages = _pages;
            this.price = _price;
            this.genre = _genre;
        }

        public int Id { get { return id; } }
        public String Name
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
        public Genre Genre
        {
            get { return genre; }
            set { genre = value; }
        }
        public State State
        {
            get { return state; }
            set { state = value; }
        }

        // override Equals and GetHashCode for easier comparison in repository
        public override bool Equals(object? obj)
        {
            return obj is Book book &&
                   id == book.id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id);
        }
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
