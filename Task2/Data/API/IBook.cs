namespace DataLayer.API
{
    public interface IBook
    {
        int Id { get; }
        string Name { get; set; }
        int Pages { get; set; }
        double Price { get; set; }
    }
}
