using System;

namespace BookstoreSystem.Data
{
    public interface ICustomer
    {
        public int Id { get; }
        public String Name { get; set; }
        public String Surname { get; set; }
    }
}