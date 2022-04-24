namespace BookstoreSystem.Data.API
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
