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
        private int amount;

        public State(Book book, int _amount = 0)
        {
            this.book = book;
            this.amount = _amount;
        }

        public Book Book
        {
            get { return book; }
            set { this.book = value; }
        }

        public int Amount
        { 
            get { return amount; } 
            set { this.amount = value;  }
        }
    }
}
