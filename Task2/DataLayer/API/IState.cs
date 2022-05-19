namespace DataLayer.API
{
    public interface IState
    {
        int Id { get; }
        IBook Book
        { get ; set; }

        int Amount
        { get; set; }

    }
}
