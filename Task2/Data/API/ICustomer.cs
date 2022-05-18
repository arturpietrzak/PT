namespace DataLayer.API
{
    public interface ICustomer
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}