using System;
using System.Collections.Generic;

namespace DataLayer.API
{
    internal interface IDataLayerAPI
    {
        // Create Read Update Delete (CRUD)

        // For IBook
        bool CreateBook(int ID, String name, int pages, double price);
        ICollection<IBook> GetAllBooks();
        IBook GetBook(int ID);
        bool UpdateBookName(int ID, String name);
        bool UpdateBookPages(int ID, int pages);
        bool UpdateBookPrice(int ID, double price);
        bool DeleteBook(int ID);

        // For ICustomer
        bool CreateCustomer(int ID, String name, String surname);
        ICollection<ICustomer> GetAllCustomers();
        ICustomer GetCustomer(int ID);
        bool UpdateCustomerName(int ID, String name);
        bool UpdateCustomerSurname(int ID, String surname);
        bool DeleteCustomer(int ID);

        // For IEvent
        bool CreateEvent(int id, IState state, ICustomer customer, DateTime dateTime);
        ICollection<IEvent> GetAllEvents();
        IEvent GetEvent(int id);
        bool UpdateEventState(int id, IState state);
        bool UpdateEventCustomer(int id, ICustomer customer);
        bool UpdateEventDateTime(int id, DateTime dateTime);
        bool DeleteEvent(int id);

        // For IState
        bool CreateState(IBook book, int amount);
        ICollection<IState> GetAllStates();
        IState GetStateForBook(IBook book);
        bool UpdateStateAmount(IBook book, int amount);
        bool DeleteState(IBook book);
    }
}
