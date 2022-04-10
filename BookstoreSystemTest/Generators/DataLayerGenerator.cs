using BookstoreSystem.Data;
using BookstoreSystem.Data.API;

namespace BookstoreSystemTest.Generators
{
    public class DataLayerGenerator : IGenerator
    {
        public DataLayerAbstractAPI Generate()
        {
            DataLayerAbstractAPI layer = DataLayerAbstractAPI.CreateSimpleAPIImplementation();

            // add books
            Book b0 = new Book(0, "Winnie-the-Pooh", 120, 9.99, Genre.adventure);
            Book b1 = new Book(1, "The lord of the rings", 300, 20.99, Genre.fantasy);
            Book b2 = new Book(2, "Moby Dick", 180, 15.99, Genre.adventure);
            Book b3 = new Book(3, "Harry Potter and the Philosopher's Stone", 300, 10.99, Genre.fantasy);
            Book b4 = new Book(4, "Percy Jackson and the Lightning Thief ", 250, 25.99, Genre.fantasy);
            Book b5 = new Book(5, "Sword of Destiny. The Witcher", 400, 25.99, Genre.fantasy);
            Book b6 = new Book(6, "Metro 2033", 458, 18.99, Genre.scifi);
            Book b7 = new Book(7, "The Call of Cthulhu", 30, 5.99, Genre.fantasy);
            Book b8 = new Book(8, "Da Vinci Code", 360, 20.40, Genre.thriller);
            Book b9 = new Book(9, "Harry Potter and the Deathly Hallows", 470, 23.20, Genre.fantasy);
            Book b10 = new Book(10, "Twilight", 380, 10.30, Genre.fantasy);

            layer.AddBook(b0);
            layer.AddBook(b1);
            layer.AddBook(b2);
            layer.AddBook(b3);
            layer.AddBook(b4);
            layer.AddBook(b5);
            layer.AddBook(b6);
            layer.AddBook(b7);
            layer.AddBook(b8);
            layer.AddBook(b9);
            layer.AddBook(b10);

            // add clients
            Customer c0 = new Customer(0, "Jan", "Kowalski");
            Customer c1 = new Customer(1, "Stefan", "Urbanski");
            Customer c2 = new Customer(2, "Bartosz", "Topolski");
            Customer c3 = new Customer(3, "Piotr", "Adamczyk");
            Customer c4 = new Customer(4, "Jan", "Sienkiewicz");
            Customer c5 = new Customer(5, "John", "Smith");
            Customer c6 = new Customer(6, "Jack", "Brown");
            Customer c7 = new Customer(7, "Johny", "Johnson");

            layer.AddCustomer(c0);
            layer.AddCustomer(c1);
            layer.AddCustomer(c2);
            layer.AddCustomer(c3);
            layer.AddCustomer(c4);
            layer.AddCustomer(c5);
            layer.AddCustomer(c6);
            layer.AddCustomer(c7);

            // add states
            State s0 = new State(b0, 0);
            State s1 = new State(b1, 3);
            State s2 = new State(b2, 1);
            State s3 = new State(b3, 456);
            State s4 = new State(b4, 871);
            State s5 = new State(b5, 72);
            State s6 = new State(b8, 3);
            State s7 = new State(b9, 5);
            State s8 = new State(b10, 6);

            layer.AddState(s0);
            layer.AddState(s1);
            layer.AddState(s2);
            layer.AddState(s3);
            layer.AddState(s4);
            layer.AddState(s5);
            layer.AddState(s6);
            layer.AddState(s7);
            layer.AddState(s8);

            // add events
            Event e0 = new EventPurchase(s5, c4);
            Event e1 = new EventPurchase(s2, c4);
            Event e2 = new EventReturn(s3, c4);
            Event e3 = new EventPurchase(s4, c4);
            Event e4 = new EventReturn(s0, c1);
            Event e5 = new EventPurchase(s4, c0);

            layer.AddEvent(e0);
            layer.AddEvent(e1);
            layer.AddEvent(e2);
            layer.AddEvent(e3);
            layer.AddEvent(e4);
            layer.AddEvent(e5);

            // return created DataContext
            return layer;
        }
    }
}
