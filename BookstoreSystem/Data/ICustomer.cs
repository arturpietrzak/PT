namespace BookstoreSystem.Data.API
{
    public interface ICustomer
    {
        public int Id { get; }
        public String Name { get; set; }
        public String Surname { get; set; }
    }
}