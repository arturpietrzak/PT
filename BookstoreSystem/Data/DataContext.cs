using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreSystem.Data
{
    public class DataContext
    {
        // From UML:
        // catalog
        public List<Book> books = new List<Book>();
        // users
        public List<Customer> customers = new List<Customer>();
        // events
        public List<Event> events = new List<Event>();
        // states
        public List<State> states = new List<State>();
    }
}
