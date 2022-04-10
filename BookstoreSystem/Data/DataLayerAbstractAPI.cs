using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreSystem.Data.API
{
    public abstract class DataLayerAbstractAPI
    {
        public abstract List<Book> AllBooks();
        public abstract Book BookById(int _id);
        public abstract void AddBook(Book book);
        public abstract void DeleteBook(Book book);
        public abstract List<Customer> AllCustomers();
        public abstract Customer CustomerById(int _id);
        public abstract void AddCustomer(Customer customer);
        public abstract void DeleteCustomer(Customer customer);
        public abstract List<Event> AllEvents();
        public abstract void AddEvent(Event _event);
        public abstract void DeleteEvent(Event _event);
        public abstract List<State> AllStates();
        public abstract State GetStateByBook(Book book);
        public abstract void AddState(State state);
        public abstract void DeleteState(State state);


        public abstract void Connect();

        // factory method
        public static DataLayerAbstractAPI CreateSimpleAPIImplementation()
        {
            return new SimpleAPIImplementation();
        }


        private class SimpleAPIImplementation : DataLayerAbstractAPI
        {
            private DataRepository repository;
            public SimpleAPIImplementation()
            {
                this.repository = new DataRepository();
            }

            public override void Connect()
            {
                // some connection
            }

            // Immplementing all other API abstract methods
            public override void AddBook(Book book)
            {
                this.repository.AddBook(book);
            }

            public override void AddCustomer(Customer customer)
            {
                this.repository.AddCustomer(customer);
            }

            public override void AddEvent(Event _event)
            {
                this.repository.AddEvent(_event);
            }

            public override void AddState(State state)
            {
                this.repository.AddState(state);
            }

            public override List<Book> AllBooks()
            {
                return this.repository.AllBooks();
            }

            public override List<Customer> AllCustomers()
            {
                return this.repository.AllCustomers();
            }

            public override List<Event> AllEvents()
            {
                return this.repository.AllEvents();
            }

            public override List<State> AllStates()
            {
                return this.repository.AllStates();
            }

            public override Book BookById(int _id)
            {
                return this.repository.BookById(_id);
            }

            public override Customer CustomerById(int _id)
            {
                return this.repository.CustomerById(_id);
            }

            public override void DeleteBook(Book book)
            {
                this.repository.DeleteBook(book);
            }

            public override void DeleteCustomer(Customer customer)
            {
                this.repository.DeleteCustomer(customer);
            }

            public override void DeleteEvent(Event _event)
            {
                this.repository.DeleteEvent(_event);
            }

            public override void DeleteState(State state)
            {
                this.repository.DeleteState(state);
            }

            public override State GetStateByBook(Book book)
            {
                return this.repository.GetStateByBook(book);
            }
        }
    }


}
