using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreSystem.Data.API
{
    public abstract class DataLayerAbstractAPI
    {
        public abstract List<IBook> AllBooks();
        public abstract IBook BookById(int _id);
        public abstract void AddBook(IBook book);
        public abstract void DeleteBook(IBook book);
        public abstract List<ICustomer> AllCustomers();
        public abstract ICustomer CustomerById(int _id);
        public abstract void AddCustomer(ICustomer customer);
        public abstract void DeleteCustomer(ICustomer customer);
        public abstract List<IEvent> AllEvents();
        public abstract void AddEvent(IEvent _event);
        public abstract void DeleteEvent(IEvent _event);
        public abstract List<IState> AllStates();
        public abstract IState GetStateByBook(IBook book);
        public abstract void AddState(IState state);
        public abstract void DeleteState(IState state);


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
            public override void AddBook(IBook book)
            {
                this.repository.AddBook(book);
            }

            public override void AddCustomer(ICustomer customer)
            {
                this.repository.AddCustomer(customer);
            }

            public override void AddEvent(IEvent _event)
            {
                this.repository.AddEvent(_event);
            }

            public override void AddState(IState state)
            {
                this.repository.AddState(state);
            }

            public override List<IBook> AllBooks()
            {
                return this.repository.AllBooks();
            }

            public override List<ICustomer> AllCustomers()
            {
                return this.repository.AllCustomers();
            }

            public override List<IEvent> AllEvents()
            {
                return this.repository.AllEvents();
            }

            public override List<IState> AllStates()
            {
                return this.repository.AllStates();
            }

            public override IBook BookById(int _id)
            {
                return this.repository.BookById(_id);
            }

            public override ICustomer CustomerById(int _id)
            {
                return this.repository.CustomerById(_id);
            }

            public override void DeleteBook(IBook book)
            {
                this.repository.DeleteBook(book);
            }

            public override void DeleteCustomer(ICustomer customer)
            {
                this.repository.DeleteCustomer(customer);
            }

            public override void DeleteEvent(IEvent _event)
            {
                this.repository.DeleteEvent(_event);
            }

            public override void DeleteState(IState state)
            {
                this.repository.DeleteState(state);
            }

            public override IState GetStateByBook(IBook book)
            {
                return this.repository.GetStateByBook(book);
            }
        }
    }


}
