using BookstoreSystem.Data.API;


namespace BookstoreSystem.Data
{
    internal class DataRepository
    {
        private DataContext dataContext;

        public DataRepository ()
        {
            this.dataContext = new DataContext();
        }

        public DataRepository(DataContext dataContext)
        {
            this.dataContext = new DataContext();
        }

        // for Book
        public List<IBook> AllBooks()
        {
            return dataContext.books;
        }

        public IBook BookById(int _id)
        {
            IBook foundBook = dataContext.books.FirstOrDefault(b => b.Id == _id);

            return foundBook;
        }

        public void AddBook(IBook book)
        {
            // check if the book is null or it is already in the data context
            if (book == null)
            {
                throw new Exception("Parsed book was null");
            }
            else if (dataContext.books.FirstOrDefault(b => b.Id == book.Id) != null)
            {
                throw new Exception("Book with id = " + book.Id + " is already in the data context");
            }
            dataContext.books.Add(book);
        }

        public void DeleteBook(IBook book)
        {
            // check if the book is null or it is not in the data context
            if (book == null)
            {
                throw new Exception("Parsed book was null");
            }
            else if (dataContext.books.FirstOrDefault(b => b.Id == book.Id) == null)
            {
                throw new Exception("Book with id = " + book.Id + " is not present in the data context");
            }
            dataContext.books.Remove(book);
        }

        // for Customer
        public List<ICustomer> AllCustomers()
        {
            return dataContext.customers;
        }

        public ICustomer CustomerById(int _id)
        {
            ICustomer foundCustomer = dataContext.customers.FirstOrDefault(c => c.Id == _id);

            return foundCustomer;
        }

        public void AddCustomer (ICustomer customer)
        {
            // check if the customer is null or he is already in the data context
            if (customer == null)
            {
                throw new Exception("Parsed customer was null");
            }
            else if (dataContext.customers.FirstOrDefault(c => c.Id == customer.Id) != null)
            {
                throw new Exception("Customer with id = " + customer.Id + " is already in the data context");
            }
            dataContext.customers.Add(customer);
        }

        public void DeleteCustomer(ICustomer customer)
        {
            // check if the customer is null or he is not in the data context
            if (customer == null)
            {
                throw new Exception("Parsed customer was null");
            }
            else if (dataContext.customers.FirstOrDefault(c => c.Id == customer.Id) == null)
            {
                throw new Exception("Customer with id = " + customer.Id + " is not in the data context");
            }
            dataContext.customers.Remove(customer);
        }

        // for Events
        public List<IEvent> AllEvents()
        {
            return dataContext.events;
        }

        public void AddEvent(IEvent _event)
        {
            // check if event is already in the data context
            if (dataContext.events.Contains(_event))
            {
                throw new Exception("Event is already in the data context");
            }
            dataContext.events.Add(_event);
        }

        public void DeleteEvent(IEvent _event)
        {
            // check if event is not in the data context
            if (!dataContext.events.Contains(_event))
            {
                throw new Exception("Event is not in the data context");
            }
        }

        // for States
        public List<IState> AllStates()
        {
            return dataContext.states;
        }

        public IState GetStateByBook(IBook book)
        {
            return dataContext.states.FirstOrDefault(s => s.Book.Id == book.Id);
        }

        public void AddState(IState state)
        {
            // check if state is already in the data context
            if (dataContext.states.Contains(state))
            {
                throw new Exception("State is already in the data context");
            }
            dataContext.states.Add(state);
        }

        public void DeleteState(IState state)
        {
            if (!dataContext.states.Contains(state))
            {
                throw new Exception("State is not in the data context");
            }
            dataContext.states.Remove(state);
        }
    }
}
