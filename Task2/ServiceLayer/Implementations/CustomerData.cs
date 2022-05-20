using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.API;

namespace ServiceLayer
{
    internal class CustomerData : ICustomerData
    {
        public CustomerData(int customer_Id, string name, string surname)
        {
            Customer_Id = customer_Id;
            Name = name;
            Surname = surname;
        }

        public override int Customer_Id { get; }
        public override string Name { get; }
        public override string Surname { get; }
    }
}
