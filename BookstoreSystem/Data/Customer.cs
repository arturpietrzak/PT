using System;

namespace BookstoreSystem.Data
{
    public class Customer
    {
        private int id;
        private String name;
        private String surname;

        public Customer(int _id, String _name, String _surname)
        {
            this.id = _id;
            this.name = _name;
            this.surname = _surname;
        }

        public int Id { get; }
        public String Name { get; set; }
        public String Surname { get; set; }
    }
}