using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.API
{
    public interface IBookService
    {
        // Create
        bool AddBook(int book_id, String name, int pages, double price);
        // Read
        ICollection<IBookData> GetAllBooks();
        ICollection<IBookData> GetAllBooksByTitle(string title); // multiple books can have the same name
        IBookData GetBookById(int id);
        // Update
        bool UpdateBook(int book_id, String name, int pages, double price);
        // Delete
        bool DeleteBook(int book_id);
    }
}
