using BookstoreSystem.Data.API;
using BookstoreSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreSystem.Logic.API
{
    public abstract class LogicLayerAPI
    {
        public static LogicLayerAPI CreateLayer(DataLayerAbstractAPI? data = default)
        {
            return new LogicLayer(data ?? DataLayerAbstractAPI.CreateSimpleAPIImplementation());
        }

        // Book
        public abstract void AddBook(int id, string name, int pages,
            double price, Genre genre, int amount = 0);
        public abstract List<Book> GetAllBooks();
        public abstract List<Event> GetAllBookEvents(Book book);
        public abstract Book GetBookById(int id);
        public abstract void RemoveBook(int id);

        // Customer  
        public abstract void AddCustomer(int id, String name, String surname);
        public abstract List<Customer> GetAllCustomers();
        public abstract List<Event> GetAllCustomerEvents(Customer customer);
        public abstract Customer GetCustomerById(int id);
        public abstract void RemoveCustomer(int id);

        // Actions  
        public abstract void SellBook(int bookId, int customerId);
        public abstract void ReturnBook(int bookId, int customerId);

        private class LogicLayer : LogicLayerAPI
        {
            private readonly DataLayerAbstractAPI dataLayer;
            public LogicLayer(DataLayerAbstractAPI data)
            {
                dataLayer = data;
                dataLayer.Connect();
            }


            // implementing abstract methods
            // Book
            public override void AddBook(int id, string name, int pages, double price, Genre genre, int amount = 0)
            {
                Book foundBook = dataLayer.BookById(id);
                if (foundBook != null)
                {
                    throw new Exception("There is already book with id = " + id);
                }
                Book newBook = new Book(id, name, pages, price, genre);
                dataLayer.AddBook(newBook);
                dataLayer.AddState(new State(newBook, amount));
            }
            public override List<Book> GetAllBooks()
            {
                return dataLayer.AllBooks();
            }
            public override List<Event> GetAllBookEvents(Book book)
            {
                Book foundBook = dataLayer.BookById(book.Id);
                if (foundBook == null)
                {
                    throw new Exception("There is no book with id = " + book.Id);
                }

                List<Event> events = new List<Event>();

                foreach (Event e in dataLayer.AllEvents())
                {
                    if (e.State.Book.Id == book.Id)
                    {
                        events.Add(e);
                    }
                }
                return events;
            }
            public override Book GetBookById(int id)
            {
                Book foundBook = dataLayer.BookById(id);
                if (foundBook == null)
                {
                    throw new Exception("There is no book with id = " + id);
                }
                return foundBook;
            }
            public override void RemoveBook(int id)
            {
                Book foundBook = dataLayer.BookById(id);
                if (foundBook == null)
                {
                    throw new Exception("There is no book with id = " + id);
                }
                dataLayer.GetStateByBook(foundBook).Amount = 0;
                dataLayer.GetStateByBook(foundBook).Book = null;
                dataLayer.DeleteBook(foundBook);
            }

            // Customer  
            public override void AddCustomer(int id, string name, string surname)
            {
                Customer foundCustomer = dataLayer.CustomerById(id);
                if (foundCustomer != null)
                {
                    throw new Exception("There is already customer with id = " + id);
                }
                Customer customer = new Customer(id, name, surname);
                dataLayer.AddCustomer(customer);
            }
            public override List<Customer> GetAllCustomers()
            {
                return dataLayer.AllCustomers();
            }
            public override List<Event> GetAllCustomerEvents(Customer customer)
            {
                Customer foundCustomer = dataLayer.CustomerById(customer.Id);
                if (foundCustomer == null)
                {
                    throw new Exception("There is no customer with id = " + customer.Id);
                }

                List<Event> events = new List<Event>();

                foreach (Event e in dataLayer.AllEvents())
                {
                    if (e.Customer.Id == customer.Id)
                    {
                        events.Add(e);
                    }
                }
                return events;
            }
            public override Customer GetCustomerById(int id)
            {
                Customer foundCustomer = dataLayer.CustomerById(id);
                if (foundCustomer == null)
                {
                    throw new Exception("There is no customer with id = " + id);
                }
                return foundCustomer;
            }
            public override void RemoveCustomer(int id)
            {
                dataLayer.DeleteCustomer(GetCustomerById(id));
            }

            // Actions
            public override void SellBook(int bookId, int customerId)
            {
                Book foundBook = dataLayer.BookById(bookId);
                if (foundBook == null)
                {
                    throw new Exception("There is no book with id = " + bookId + ". Cannot sell book. ");
                }

                if (dataLayer.GetStateByBook(foundBook) == null)
                {
                    dataLayer.AddEvent(new EventReturn(null, dataLayer.CustomerById(customerId)));
                }
                else
                {
                    // decrease by 1
                    dataLayer.GetStateByBook(foundBook).Amount -= 1;
                    dataLayer.AddEvent(new EventPurchase(dataLayer.GetStateByBook(foundBook), dataLayer.CustomerById(customerId)));
                }
            }
            public override void ReturnBook(int bookId, int customerId)
            {
                Book foundBook = dataLayer.BookById(bookId);
                if (foundBook == null)
                {
                    throw new Exception("There is no book with id = " + bookId + ". Cannot return book. ");
                }

                if (dataLayer.GetStateByBook(foundBook) == null)
                {
                    dataLayer.AddEvent(new EventReturn(null, dataLayer.CustomerById(customerId)));
                }
                else
                {
                    // increment by 1
                    dataLayer.GetStateByBook(foundBook).Amount += 1;
                    dataLayer.AddEvent(new EventReturn(dataLayer.GetStateByBook(foundBook), dataLayer.CustomerById(customerId)));
                }
            }

        }
    }
}
