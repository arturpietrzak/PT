namespace DataLayer.API
{
    public interface ICustomer
    {
        int Id { get; }
        string Name { get; set; }
        string Surname { get; set; }
    }
}