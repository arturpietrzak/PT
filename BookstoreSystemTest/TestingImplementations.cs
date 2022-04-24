using BookstoreSystem.Data;
using System;

namespace BookstoreSystemTest
{
    internal class TBook : IBook
    {
        private int id;
        private String name;
        private int pages;
        private double price;
        private Genre genre;

        public TBook(int _id, string _name, int _pages,
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

        // override Equals and GetHashCode for easier comparison in repository
        public override bool Equals(object? obj)
        {
            return obj is TBook book &&
                   id == book.id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id);
        }
    }

    internal class TCustomer : ICustomer
    {
        private int id;
        private String name;
        private String surname;

        public TCustomer(int _id, String _name, String _surname)
        {
            this.id = _id;
            this.name = _name;
            this.surname = _surname;
        }

        public int Id { get { return id; } }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public String Surname
        {
            get { return surname; }
            set { surname = value; }
        }


        // override Equals and GetHashCode for easier comparison in repository
        public override bool Equals(object? obj)
        {
            return obj is TCustomer customer &&
                    id == customer.id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id);
        }
    }

    internal class TState : IState
    {
        private IBook book;
        private int amount;

        public TState(IBook book, int _amount = 0)
        {
            this.book = book;
            this.amount = _amount;
        }

        public IBook Book
        {
            get { return book; }
            set { this.book = value; }
        }

        public int Amount
        {
            get { return amount; }
            set { this.amount = value; }
        }
    }

    internal class TEventReturn : IEvent
    {
        private IState state;
        private ICustomer customer;
        private DateTime eventDate;

        public TEventReturn(IState _state, ICustomer _client)
        {
            this.state = _state;
            this.customer = _client;
            this.eventDate = DateTime.Now;
        }

        public IState State { get { return this.state; } }
        public ICustomer Customer { get { return this.customer; } }
        public DateTime EventDate { get { return this.eventDate; } }
    }

    internal class TEventPurchase : IEvent
    {
        private IState state;
        private ICustomer customer;
        private DateTime eventDate;

        public TEventPurchase(IState _state, ICustomer _client)
        {
            this.state = _state;
            this.customer = _client;
            this.eventDate = DateTime.Now;
        }

        public IState State { get { return this.state; } }
        public ICustomer Customer { get { return this.customer; } }
        public DateTime EventDate { get { return this.eventDate; } }
    }
}
