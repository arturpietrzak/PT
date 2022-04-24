using BookstoreSystem.Logic.API;
using BookstoreSystem.Data.API;

namespace BookstoreSystem.Logic
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
        public List<IBook> GetAllBooks()
        {
            return this.connection.GetAllBooks();
        }
        public List<IEvent> GetAllBookEvents(int id)
        {
            IBook book = GetBookById(id);
            return this.connection.GetAllBookEvents(book);
        }
        public IBook GetBookById(int id)
        {
            return this.connection.GetBookById(id);
        }
        public void RemoveBook(int id) { 
            this.connection.RemoveBook(id);
        }
        public int GetBookStockById(int id)
        {
            return this.connection.GetBookStockById(id);
        }
        public void SetBookStockById(int id, int amount)
        {
             this.connection.SetBookStockById(id, amount);
        }

        // Customer  
        public void AddCustomer(int id, String name, String surname)
        {
            this.connection.AddCustomer(id, name, surname); 
        }
        public List<ICustomer> GetAllCustomers()
        {
            return this.connection.GetAllCustomers();
        }
        public List<IEvent> GetAllCustomerEvents(int id)
        {
            return this.connection.GetAllCustomerEvents(GetCustomerById(id));
        }
        public ICustomer GetCustomerById(int id)
        {
            return this.connection.GetCustomerById(id);
        }
        public void RemoveCustomer(int id)
        {
            this.connection.RemoveCustomer(id);
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