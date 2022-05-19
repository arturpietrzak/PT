using DataLayer.API;

namespace DataLayer.Implementations
{
    internal class State : IState
    {
        private int id;
        private IBook book;
        private int amount;

        public State(int id, IBook book, int _amount = 0)
        {
            this.id = id;
            this.book = book;
            this.amount = _amount;
        }

        public int Id
        {
            get { return id; }
        }

        public IBook Book
        {
            get { return book; }
            set { book = value; }
        }

        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
    }
}
