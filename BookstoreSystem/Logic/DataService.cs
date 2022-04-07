using BookstoreSystem.Data;
using BookstoreSystem.Logic;
using BookstoreSystem.Logic.API;

namespace BookstoreSystem.logic
{
    public class DataService
    {
        private LogicLayerAPI connection;

        public DataService(LogicLayerAPI logic)
        {
            this.connection = logic;
        }

        // Book
        public void AddBook(int id, string name, int pages,
            double price, Genre genre, int amount = 0)
        {
            this.connection.AddBook(id, name, pages, price, genre, amount);
        }
        public List<Book> GetAllBooks()
        {
            return this.connection.GetAllBooks();
        }
        public List<Event> GetAllBookEvents(int id)
        {
            Book book = GetBookById(id);
            return this.connection.GetAllBookEvents(book);
        }
        public Book GetBookById(int id)
        {
            return this.connection.GetBookById(id);
        }
        public void RemoveBook(int id) { 
            this.connection.RemoveBook(id);
        }  

        // Customer  
        public void AddCustomer(int id, String name, String surname)
        {
            this.connection.AddCustomer(id, name, surname); 
        }
        public List<Customer> GetAllCustomers()
        {
            return this.GetAllCustomers();
        }
        public List<Event> GetAllCustomerEvents(int id)
        {
            return this.connection.GetAllCustomerEvents(GetCustomerById(id));
        }
        public Customer GetCustomerById(int id)
        {
            return this.connection.GetCustomerById(id);
        }
        public void RemoveCustomer(int id)
        {
            this.RemoveCustomer(id);
        }

        // Actions  
        public void SellBook(int bookId, int customerId)
        {
            this.connection.SellBook(bookId, customerId);  
        }
        public void ReturnBook(int bookId, int customerId)
        {
            this.connection.ReturnBook(bookId, customerId);
        }
    }
}