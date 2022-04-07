using BookstoreSystem.Data;
using BookstoreSystem.Data.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreSystem.Logic
{
    public class DataRepository
    {
        private DataContext dataContext;

        public DataRepository (DataContext _dataContext)
        {
            this.dataContext = _dataContext;
        }

        // for Book
        List<Book> AllBooks()
        {
            return dataContext.books;
        }

        Book BookById(int _id)
        {
            Book foundBook = dataContext.books.FirstOrDefault(b => b.Id == _id);
            if (foundBook == null)
            {
                throw new Exception("No book with id = " + _id + " in the data context");
            }
            return foundBook;
        }

        void AddBook(Book book)
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

        void DeleteBook(Book book)
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
        List<Customer> AllCustomers()
        {
            return dataContext.customers;
        }

        Customer CustomerById(int _id)
        {
            Customer foundCustomer = dataContext.customers.FirstOrDefault(c => c.Id == _id);
            if (foundCustomer == null)
            {
                throw new Exception("No customer with id = " + _id + " in the data context");
            }
            return foundCustomer;
        }

        void AddCustomer (Customer customer)
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

        void DeleteCustomer(Customer customer)
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
        List<Event> AllEvents()
        {
            return dataContext.events;
        }

        void AddEvent(Event _event)
        {
            // check if event is already in the data context
            if (dataContext.events.Contains(_event))
            {
                throw new Exception("Event is already in the data context");
            }
            dataContext.events.Remove(_event);
        }

        void DeleteEvent(Event _event)
        {
            // check if event is not in the data context
            if (!dataContext.events.Contains(_event))
            {
                throw new Exception("Event is not in the data context");
            }
        }

        // for States
        List<State> AllStates()
        {
            return dataContext.states;
        }

        void AddState(State state)
        {
            // check if state is already in the data context
            if (dataContext.states.Contains(state))
            {
                throw new Exception("State is already in the data context");
            }
            dataContext.states.Remove(state);
        }

        void DeleteState(State state)
        {
            if (!dataContext.states.Contains(state))
            {
                throw new Exception("State is not in the data context");
            }
            dataContext.states.Remove(state);
        }
    }
}
