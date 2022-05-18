using System;
using DataLayer.API;

namespace DataLayer.Implementations
{
    internal class Customer : ICustomer
    {
        private int id;
        private string name;
        private string surname;

        public Customer(int _id, string _name, string _surname)
        {
            id = _id;
            name = _name;
            surname = _surname;
        }

        public int Id
        {
            get { return id; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }


        // override Equals and GetHashCode for easier comparison in repository
        public override bool Equals(object? obj)
        {
            return obj is Customer customer &&
                id == customer.id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id);
        }
    }
}
