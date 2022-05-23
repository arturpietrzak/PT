using System;
using System.Collections.Generic;
using PresentationLayer.API;

namespace PresentationLayer
{
    internal class CustomerModelData : ICustomerModelData
    {
        public int Customer_Id { get; set;  }
        public string Name { get; set; }
        public string Surname { get; set; }

        public CustomerModelData(int customer_Id, string name, string surname)
        {
            Customer_Id = customer_Id;
            Name = name;
            Surname = surname;
        }
    }
}
