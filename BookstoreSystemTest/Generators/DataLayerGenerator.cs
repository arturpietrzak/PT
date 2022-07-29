using BookstoreSystem;
using BookstoreSystem.Data.API;

namespace BookstoreSystemTest.Generators
{
    public class DataLayerGenerator : IGenerator
    {
        public DataLayerAbstractAPI Generate()
        {
            DataLayerAbstractAPI layer = DataLayerAbstractAPI.CreateSimpleAPIImplementation();

            // add books
            IBook b0 = new TBook(0, "Winnie-the-Pooh", 120, 9.99, Genre.adventure);
            IBook b1 = new TBook(1, "The lord of the rings", 300, 20.99, Genre.fantasy);
            IBook b2 = new TBook(2, "Moby Dick", 180, 15.99, Genre.adventure);
            IBook b3 = new TBook(3, "Harry Potter and the Philosopher's Stone", 300, 10.99, Genre.fantasy);
            IBook b4 = new TBook(4, "Percy Jackson and the Lightning Thief ", 250, 25.99, Genre.fantasy);
            IBook b5 = new TBook(5, "Sword of Destiny. The Witcher", 400, 25.99, Genre.fantasy);
            IBook b6 = new TBook(6, "Metro 2033", 458, 18.99, Genre.scifi);
            IBook b7 = new TBook(7, "The Call of Cthulhu", 30, 5.99, Genre.fantasy);
            IBook b8 = new TBook(8, "Da Vinci Code", 360, 20.40, Genre.thriller);
            IBook b9 = new TBook(9, "Harry Potter and the Deathly Hallows", 470, 23.20, Genre.fantasy);
            IBook b10 = new TBook(10, "Twilight", 380, 10.30, Genre.fantasy);

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
            ICustomer c0 = new TCustomer(0, "Piotr", "Kowalski");
            ICustomer c1 = new TCustomer(1, "Ela", "Urbanska");
            ICustomer c2 = new TCustomer(2, "Norbert", "Topolski");
            ICustomer c3 = new TCustomer(3, "Iga", "Adamczyk");
            ICustomer c4 = new TCustomer(4, "Szymon", "Sienkiewicz");
            ICustomer c5 = new TCustomer(5, "John", "Smith");
            ICustomer c6 = new TCustomer(6, "Jack", "Brown");
            ICustomer c7 = new TCustomer(7, "Johny", "Johnson");

            layer.AddCustomer(c0);
            layer.AddCustomer(c1);
            layer.AddCustomer(c2);
            layer.AddCustomer(c3);
            layer.AddCustomer(c4);
            layer.AddCustomer(c5);
            layer.AddCustomer(c6);
            layer.AddCustomer(c7);

            // add states
            IState s0 = new TState(b0, 0);
            IState s1 = new TState(b1, 3);
            IState s2 = new TState(b2, 1);
            IState s3 = new TState(b3, 456);
            IState s4 = new TState(b4, 871);
            IState s5 = new TState(b5, 72);
            IState s6 = new TState(b8, 3);
            IState s7 = new TState(b9, 5);
            IState s8 = new TState(b10, 6);

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
            IEvent e0 = new TEventPurchase(s5, c4);
            IEvent e1 = new TEventPurchase(s2, c4);
            IEvent e2 = new TEventReturn(s3, c4);
            IEvent e3 = new TEventPurchase(s4, c4);
            IEvent e4 = new TEventReturn(s0, c1);
            IEvent e5 = new TEventPurchase(s4, c0);

            layer.AddEvent(e0);
            layer.AddEvent(e1);
            layer.AddEvent(e2);
            layer.AddEvent(e3);
            layer.AddEvent(e4);
            layer.AddEvent(e5);

            // return created layer
            return layer;
        }
    }
}
