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
        public abstract List<IBook> GetAllBooks();
        public abstract List<IEvent> GetAllBookEvents(IBook book);
        public abstract IBook GetBookById(int id);
        public abstract void RemoveBook(int id);
        public abstract int GetBookStockById(int id);
        public abstract void SetBookStockById(int id, int amount);

        // Customer  
        public abstract void AddCustomer(int id, String name, String surname);
        public abstract List<ICustomer> GetAllCustomers();
        public abstract List<IEvent> GetAllCustomerEvents(ICustomer customer);
        public abstract ICustomer GetCustomerById(int id);
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
                IBook foundBook = dataLayer.BookById(id);
                if (foundBook != null)
                {
                    throw new Exception("There is already book with id = " + id);
                }
                IBook newBook = new Book(id, name, pages, price, genre);
                dataLayer.AddBook(newBook);
                dataLayer.AddState(new State(newBook, amount));
            }
            public override List<IBook> GetAllBooks()
            {
                return dataLayer.AllBooks();
            }
            public override List<IEvent> GetAllBookEvents(IBook book)
            {
                IBook foundBook = dataLayer.BookById(book.Id);
                if (foundBook == null)
                {
                    throw new Exception("There is no book with id = " + book.Id);
                }

                List<IEvent> events = new List<IEvent>();

                foreach (IEvent e in dataLayer.AllEvents())
                {
                    if (e.State.Book.Id == book.Id)
                    {
                        events.Add(e);
                    }
                }
                return events;
            }
            public override IBook GetBookById(int id)
            {
                IBook foundBook = dataLayer.BookById(id);
                if (foundBook == null)
                {
                    throw new Exception("There is no book with id = " + id);
                }
                return foundBook;
            }
            public override void RemoveBook(int id)
            {
                IBook foundBook = dataLayer.BookById(id);
                if (foundBook == null)
                {
                    throw new Exception("There is no book with id = " + id);
                }
                dataLayer.DeleteState(dataLayer.GetStateByBook(foundBook));
                dataLayer.DeleteBook(foundBook);
            }
            public override int GetBookStockById(int id)
            {
                IBook foundBook = dataLayer.BookById(id);
                if (foundBook == null)
                {
                    throw new Exception("There is no book with id = " + id);
                }
                return dataLayer.GetStateByBook(foundBook).Amount;
            }
            public override void SetBookStockById(int id, int amount)
            {
                IBook foundBook = dataLayer.BookById(id);
                if (foundBook == null)
                {
                    throw new Exception("There is no book with id = " + id);
                }
                dataLayer.GetStateByBook(foundBook).Amount = amount;
            }

            // Customer  
            public override void AddCustomer(int id, string name, string surname)
            {
                ICustomer foundCustomer = dataLayer.CustomerById(id);
                if (foundCustomer != null)
                {
                    throw new Exception("There is already customer with id = " + id);
                }
                ICustomer customer = new Customer(id, name, surname);
                dataLayer.AddCustomer(customer);
            }
            public override List<ICustomer> GetAllCustomers()
            {
                return dataLayer.AllCustomers();
            }
            public override List<IEvent> GetAllCustomerEvents(ICustomer customer)
            {
                ICustomer foundCustomer = dataLayer.CustomerById(customer.Id);
                if (foundCustomer == null)
                {
                    throw new Exception("There is no customer with id = " + customer.Id);
                }

                List<IEvent> events = new List<IEvent>();

                foreach (IEvent e in dataLayer.AllEvents())
                {
                    if (e.Customer.Id == customer.Id)
                    {
                        events.Add(e);
                    }
                }
                return events;
            }
            public override ICustomer GetCustomerById(int id)
            {
                ICustomer foundCustomer = dataLayer.CustomerById(id);
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
                IBook foundBook = dataLayer.BookById(bookId);
                if (foundBook == null)
                {
                    throw new Exception("There is no book with id = " + bookId + ". Cannot sell book. ");
                }
                else if (dataLayer.GetStateByBook(foundBook) != null && dataLayer.GetStateByBook(foundBook).Amount < 1)
                {
                    throw new Exception("There is no book in stock. Cannot sell book. ");
                }
                else if (dataLayer.GetStateByBook(foundBook) == null)
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
                IBook foundBook = dataLayer.BookById(bookId);
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
