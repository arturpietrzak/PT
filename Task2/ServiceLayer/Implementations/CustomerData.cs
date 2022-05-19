using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.API
{
    internal class CustomerData : ICustomerData
    {
        public CustomerData(int customer_Id, string name, string surname)
        {
            Customer_Id = customer_Id;
            Name = name;
            Surname = surname;
        }

        public int Customer_Id { get; }
        public string Name { get; }
        public string Surname { get; }
    }
}
