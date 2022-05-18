namespace DataLayer.API
{
    public interface IState
    {
        public int Id { get; }
        public IBook Book
        { get ; set; }

        public int Amount
        { get; set; }

    }
}
