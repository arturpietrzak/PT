using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreSystem.Data
{
    public interface IBook
    {
        int Id { get; }
        String Name { get; set; }
        int Pages { get; set; }
        double Price { get; set; }
        Genre Genre { get; set; }
    }
}
