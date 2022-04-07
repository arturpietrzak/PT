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
        private DataLayerAbstractAPI dataContext;

        public DataRepository (DataLayerAbstractAPI _dataContext)
        {
            this.dataContext = _dataContext;
        }

        // for Book
        List<Book> AllBooks()
        {
            return dataContext.Books();
        }

        Book BookById(int _id)
        {
            Book foundBook = dataContext.Books().FirstOrDefault(b => b.Id == _id);
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
            else if (dataContext.Books().FirstOrDefault(b => b.Id == book.Id) != null)
            {
                throw new Exception("Book with id = " + book.Id + " is already in the data context");
            }
            dataContext.Books().Add(book);
        }

        void DeleteBook(Book book)
        {
            // check if the book is null or it is not in the data context
            if (book == null)
            {
                throw new Exception("Parsed book was null");
            }
            else if (dataContext.Books().FirstOrDefault(b => b.Id == book.Id) == null)
            {
                throw new Exception("Book with id = " + book.Id + " is not present in the data context");
            }
            dataContext.Books().Remove(book);
        }

        // for Customer
        List<Customer> AllCustomers()
        {
            return dataContext.Customers();
        }

        Customer CustomerById(int _id)
        {
            Customer foundCustomer = dataContext.Customers().FirstOrDefault(c => c.Id == _id);
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
            else if (dataContext.Customers().FirstOrDefault(c => c.Id == customer.Id) != null)
            {
                throw new Exception("Customer with id = " + customer.Id + " is already in the data context");
            }
            dataContext.Customers().Add(customer);
        }

        void DeleteCustomer(Customer customer)
        {
            // check if the customer is null or he is not in the data context
            if (customer == null)
            {
                throw new Exception("Parsed customer was null");
            }
            else if (dataContext.Customers().FirstOrDefault(c => c.Id == customer.Id) == null)
            {
                throw new Exception("Customer with id = " + customer.Id + " is not in the data context");
            }
            dataContext.Customers().Remove(customer);
        }

        // for Events
        List<Event> AllEvents()
        {
            return dataContext.Events();
        }

        void AddEvent(Event _event)
        {
            // check if event is already in the data context
            if (dataContext.Events().Contains(_event))
            {
                throw new Exception("Event is already in the data context");
            }
            dataContext.Events().Remove(_event);
        }

        void DeleteEvent(Event _event)
        {
            // check if event is not in the data context
            if (!dataContext.Events().Contains(_event))
            {
                throw new Exception("Event is not in the data context");
            }
        }

        // for States
        List<State> AllStates()
        {
            return dataContext.States();
        }

        void AddState(State state)
        {
            // check if state is already in the data context
            if (dataContext.States().Contains(state))
            {
                throw new Exception("State is already in the data context");
            }
            dataContext.States().Remove(state);
        }

        void DeleteState(State state)
        {
            if (!dataContext.States().Contains(state))
            {
                throw new Exception("State is not in the data context");
            }
            dataContext.States().Remove(state);
        }
    }
}
