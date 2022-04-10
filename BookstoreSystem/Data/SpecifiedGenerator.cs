using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreSystem.Data
{
    public class SpecifiedGenerator : InterfaceGenerator
    {
        public void Generate(DataContext data)
        {
            Customer customer1 = new Customer(1, "John", "Smith");
            Customer customer2 = new Customer(2, "Jack", "Brown");
            Customer customer3 = new Customer(3, "Johny", "Johnson");

            Book book1 = new Book(1, "Da Vinci Code", 360, 20.40, Genre.thriller);
            Book book2 = new Book(2, "Harry Potter and the Deathly Hallows", 470, 23.20, Genre.fantasy);
            Book book3 = new Book(3, "Twilight", 380, 10.30, Genre.fantasy);

            data.customers.Add(customer1);
            data.customers.Add(customer2);
            data.customers.Add(customer3);

            data.books.Add(book1);
            data.books.Add(book2);
            data.books.Add(book3);

            State state1 = new State(book1, 3);
            State state2 = new State(book2, 5);
            State state3 = new State(book3, 6);

            data.states.Add(state1);
            data.states.Add(state2);
            data.states.Add(state3);

        }
    }
}
