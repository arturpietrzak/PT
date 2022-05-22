using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.API;

namespace PresentationLayer
{
    internal class CustomerModelData : ICustomerModelData
    {
        public int Customer_Id { get; }
        public string Name { get; }
        public string Surname { get; }

        public CustomerModelData(int customer_Id, string name, string surname)
        {
            Customer_Id = customer_Id;
            Name = name;
            Surname = surname;
        }
    }
}
