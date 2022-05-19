using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.API;
using ServiceLayer.API;

namespace PresentationLayer.Model
{
    internal class CustomerModelView : ICustomerModelView
    {

        int Customer_Id { get; }
        string Name { get; }
        string Surname { get; }

        public CustomerModelView(int customer_id, String name, String surname)
        {
            Customer_Id = customer_id;
            Name = name;
            Surname = surname;
        }
    }
}
