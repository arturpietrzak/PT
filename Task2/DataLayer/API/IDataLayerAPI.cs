﻿using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer.Implementations;

namespace DataLayer.API
{
    public abstract class IDataLayerAPI
    {
        public abstract void Connect(String connectionString = null);
        public abstract void ClearTables();

        // Create Read Update Delete (CRUD)
        // For IBook
        public abstract bool CreateBook(int ID, String name, int pages, double price);
        public abstract ICollection<IBook> GetAllBooks();
        public abstract IBook GetBook(int ID);
        public abstract bool UpdateBook(int ID, String name, int pages, double price);
        public abstract bool DeleteBook(int ID);

        // For ICustomer
        public abstract bool CreateCustomer(int ID, String name, String surname);
        public abstract ICollection<ICustomer> GetAllCustomers();
        public abstract ICustomer GetCustomer(int ID);
        public abstract bool UpdateCustomer(int ID, String name, String surname);
        public abstract bool DeleteCustomer(int ID);

        // For IEvent
        public abstract bool CreateEvent(IState state, ICustomer customer);
        public abstract ICollection<IEvent> GetAllEvents();
        public abstract ICollection<IEvent> GetEventsForState(IState state);
        public abstract ICollection<IEvent> GetEventsForCustomer(ICustomer customer);

        // For IState
        public abstract bool CreateState(int state_id, IBook book, int amount);
        public abstract ICollection<IState> GetAllStates();
        public abstract IState GetState(int id);
        public abstract IState GetStateForBook(IBook book);
        public abstract bool UpdateStateAmount(int ID, int amount);
        public abstract bool DeleteState(int ID);

        // factory method
        public static IDataLayerAPI CreateAPIUsingSQL()
        {
            return new SQLApi();
        }

        internal class SQLApi : IDataLayerAPI
        {

            BookstoreDataContext context;

            public override void Connect(String connectionString = null)
            {
                if (connectionString == null)
                {
                    context = new BookstoreDataContext();
                } else
                {
                    context = new BookstoreDataContext(connectionString);
                }

            }

            public override void ClearTables()
            {
                context.ExecuteCommand("DELETE FROM customers");
                context.ExecuteCommand("DELETE FROM books");
                context.ExecuteCommand("DELETE FROM states");
                context.ExecuteCommand("DELETE FROM events");
            }

            // functions to transform database classess to other classess
            public ICustomer Transform(customers customer)
            {
                return new Customer(customer.customer_id, customer.surname, customer.name);
            }
            public IBook Transform(books book)
            {
                return new Book(book.book_id, book.name, book.pages, book.price);
            }

            public IEvent Transform(events evt)
            {
                return new EventPurchase(GetState(evt.state_id.Value), GetCustomer(evt.customer_id.Value));
            }

            public IState Transform(states state)
            {
                return new State(state.state_id, GetBook(state.book_id.Value), state.amount);
            }

            // For IBook
            public override bool CreateBook(int ID, string name, int pages, double price)
            {
                if (GetBook(ID) != null || name.Equals(null) || pages <= 0 || price < 0)
                {
                    return false;
                }

                books newBook = new books
                {
                    book_id = ID,
                    name = name,
                    pages = pages,
                    price = price
                };

                context.books.InsertOnSubmit(newBook);
                context.SubmitChanges();

                return true;
            }
            public override ICollection<IBook> GetAllBooks()
            {
                var booksDb = from books in context.books select books;
                List<IBook> list = new List<IBook>();
                foreach (var book in booksDb)
                {
                    list.Add(Transform(book));
                }

                return list;
            }
            public override IBook GetBook(int ID)
            {
                var bookDb = (
                    from books
                    in context.books
                    where (books.book_id == ID)
                    select books
                ).SingleOrDefault();

                if (bookDb == null)
                {
                    return null;
                }

                return Transform(bookDb);
            }
            public override bool UpdateBook(int ID, String name, int pages, double price)
            {
                books book = context.books.Where(b => b.book_id == ID).SingleOrDefault();
                if (ID.Equals(null) || name.Equals(null) || pages <= 0 || price < 0 || GetBook(ID) == null)
                {
                    return false;
                }

                book.name = name;
                book.pages = pages;
                book.price = price;
                context.SubmitChanges();

                return true;
            }

            public override bool DeleteBook(int ID)
            {
                books book = context.books.Where(b => b.book_id == ID).SingleOrDefault();

                if (GetBook(ID) == null || ID.Equals(null))
                {
                    return false;
                }

                context.books.DeleteOnSubmit(book);
                context.SubmitChanges();

                return true;
            }

            // For ICustomer
            public override bool CreateCustomer(int ID, string name, string surname)
            {
                if (GetCustomer(ID) != null || name == null || name.Length > 100 || surname == null || surname.Length > 100)
                {
                    return false;
                }

                customers newCustomer = new customers
                {
                    customer_id = ID,
                    name = name,
                    surname = surname,
                };

                context.customers.InsertOnSubmit(newCustomer);
                context.SubmitChanges();

                return true;
            }
            public override ICollection<ICustomer> GetAllCustomers()
            {
                var customersDb = from customers in context.customers select customers;
                List<ICustomer> list = new List<ICustomer>();
                foreach (var customer in customersDb)
                {
                    list.Add(Transform(customer));
                }

                return list;
            }
            public override ICustomer GetCustomer(int ID)
            {
                var customerDb = (
                    from customers
                    in context.customers
                    where (customers.customer_id == ID)
                    select customers
                ).SingleOrDefault();

                if (customerDb == null)
                {
                    return null;
                }

                return Transform(customerDb);
            }
            public override bool UpdateCustomer(int ID, String name, String surname)
            {
                customers customer = context.customers.Where(c => c.customer_id == ID).SingleOrDefault();
                if (customer == null || ID.Equals(null) || name.Equals(null) || surname.Equals(null) || name.Equals(null) || name.Length > 100 || surname.Equals(null) || surname.Length > 100)
                {
                    return false;
                }

                customer.name = name;
                customer.surname = surname;
                context.SubmitChanges();

                return true;
            }
            public override bool DeleteCustomer(int ID)
            {
                customers customer = context.customers.Where(c => c.customer_id == ID).SingleOrDefault();

                if (GetCustomer(ID) == null || ID.Equals(null))
                {
                    return false;
                }

                context.customers.DeleteOnSubmit(customer);
                context.SubmitChanges();

                return true;
            }

            // For IEvent
            public override bool CreateEvent(IState state, ICustomer customer)
            {
                if (state.Equals(null) || GetState(state.Id) == null || customer.Equals(null) || GetCustomer(customer.Id) == null)
                {
                    return false;
                }

                events newEvent = new events
                {
                    customer_id = customer.Id,
                    state_id = state.Id,
                    event_date = DateTime.Now,
                };

                context.events.InsertOnSubmit(newEvent);
                context.SubmitChanges();

                return true;
            }
            public override ICollection<IEvent> GetAllEvents()
            {
                var eventsDb = from events in context.events select events;
                List<IEvent> list = new List<IEvent>();
                foreach (var evt in eventsDb)
                {
                    list.Add(Transform(evt));
                }

                return list;
            }
            public override ICollection<IEvent> GetEventsForState(IState state)
            {
                var eventsDb = (
                    from events
                    in context.events
                    where (events.state_id == state.Id)
                    select events
                );

                List<IEvent> list = new List<IEvent>();
                foreach (var evt in eventsDb)
                {
                    list.Add(Transform(evt));
                }

                return list;
            }
            public override ICollection<IEvent> GetEventsForCustomer(ICustomer customer)
            {
                var eventsDb = (
                    from events
                    in context.events
                    where (events.customer_id == customer.Id)
                    select events
                );

                List<IEvent> list = new List<IEvent>();
                foreach (var evt in eventsDb)
                {
                    list.Add(Transform(evt));
                }

                return list;
            }

            // For IState
            public override bool CreateState(int state_id, IBook book, int amount)
            {
                if (GetStateForBook(book) != null || GetState(state_id) != null || amount < 0)
                {
                    return false;
                }

                states newState = new states
                {
                    state_id = state_id,
                    book_id = book.Id,
                    amount = amount,
                };

                context.states.InsertOnSubmit(newState);
                context.SubmitChanges();

                return true;
            }
            public override ICollection<IState> GetAllStates()
            {
                var statesDb = from states in context.states select states;
                List<IState> list = new List<IState>();
                foreach (var state in statesDb)
                {
                    list.Add(Transform(state));
                }

                return list;
            }
            public override IState GetState(int ID)
            {
                var stateDb = (
                    from states
                    in context.states
                    where (states.state_id == ID)
                    select states
                ).SingleOrDefault();

                if (stateDb == null)
                {
                    return null;
                }

                return Transform(stateDb);
            }
            public override IState GetStateForBook(IBook book)
            {
                var stateDb = (
                    from states
                    in context.states
                    where (states.book_id == book.Id)
                    select states
                ).SingleOrDefault();

                if (stateDb == null)
                {
                    return null;
                }

                return Transform(stateDb);
            }
            public override bool UpdateStateAmount(int ID, int amount)
            {
                states state = context.states.Where(s => s.state_id == ID).SingleOrDefault();

                if (GetState(ID) == null || ID.Equals(null) || amount < 0)
                {
                    return false;
                }

                state.amount = amount;
                context.SubmitChanges();

                return true;
            }
            public override bool DeleteState(int ID)
            {
                states state = context.states.Where(s => s.state_id == ID).SingleOrDefault();

                if (GetState(ID) == null || ID.Equals(null))
                {
                    return false;
                }

                context.states.DeleteOnSubmit(state);
                context.SubmitChanges();

                return true;
            }
        }
    }
}
