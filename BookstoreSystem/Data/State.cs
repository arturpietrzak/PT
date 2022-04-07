using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreSystem.Data
{
    public class State
    {
        private Book book;

        public State(Book _book)
        {
            this.book = _book;
        }

        public Book Book { get { return book; } }
    }
}
