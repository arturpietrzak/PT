using BookstoreSystem.Data;

namespace BookstoreSystemTest.Generators
{
    public class DataGenerator : IGenerator
    {
        public DataContext Generate()
        {
            DataContext context = new DataContext();

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

            context.books.Add(b0);
            context.books.Add(b1);
            context.books.Add(b2);
            context.books.Add(b3);
            context.books.Add(b4);
            context.books.Add(b5);
            context.books.Add(b6);
            context.books.Add(b7);

            // add clients
            Customer c0 = new Customer(0, "Jan", "Kowalski");
            Customer c1 = new Customer(1, "Stefan", "Urbanski");
            Customer c2 = new Customer(2, "Bartosz", "Topolski");
            Customer c3 = new Customer(3, "Piotr", "Adamczyk");
            Customer c4 = new Customer(4, "Jan", "Sienkiewicz");
            Customer c5 = new Customer(5, "John", "Smith");
            Customer c6 = new Customer(6, "Jack", "Brown");
            Customer c7 = new Customer(7, "Johny", "Johnson");

            context.customers.Add(c0);
            context.customers.Add(c1);
            context.customers.Add(c2);
            context.customers.Add(c3);
            context.customers.Add(c4);
            context.customers.Add(c5);
            context.customers.Add(c6);
            context.customers.Add(c7);

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

            context.states.Add(s0);
            context.states.Add(s1);
            context.states.Add(s2);
            context.states.Add(s3);
            context.states.Add(s4);
            context.states.Add(s5);
            context.states.Add(s6);
            context.states.Add(s7);
            context.states.Add(s8);

            // add events
            Event e0 = new EventPurchase(s5, c4);
            Event e1 = new EventPurchase(s2, c4);
            Event e2 = new EventReturn(s3, c4);
            Event e3 = new EventPurchase(s4, c4);
            Event e4 = new EventReturn(s0, c1);
            Event e5 = new EventPurchase(s4, c0);

            context.events.Add(e0);
            context.events.Add(e1);
            context.events.Add(e2);
            context.events.Add(e3);
            context.events.Add(e4);
            context.events.Add(e5);

            // return created DataContext
            return context;
        }
    }
}
