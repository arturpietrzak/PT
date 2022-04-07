using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreSystem.Data.API
{
    // DataContext
    public abstract class DataLayerAbstractAPI
    {
        // abstract connection methods
        public abstract List<Book> Books();
        public abstract List<Customer> Customers();
        public abstract List<Event> Events();
        public abstract List<State> States();

        // factory method
        public static DataLayerAbstractAPI CreateDataCollection()
        {
            return new DataCollection();
        }

        // implementation
        private class DataCollection : DataLayerAbstractAPI
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

            public override List<Book> Books()
            {
                return this.books;
            }

            public override List<Customer> Customers()
            {
                return this.customers;
            }

            public override List<Event> Events()
            {
                return this.events;
            }

            public override List<State> States()
            {
                return this.states;
            }
        }
    }


}
