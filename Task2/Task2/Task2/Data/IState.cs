namespace BookstoreSystem.Data.API
{
    public interface IState
    {
        public IBook Book
        { get ; set; }

        public int Amount
        { get; set; }

    }
}
