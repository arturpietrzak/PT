using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.API;
using ServiceLayer.API;

namespace PresentationLayer
{
    internal class CustomerModelData : ICustomerModelData
    {
        public CustomerModelData(ICustomerService service)
        {
            Service = service;
        }

        public ICustomerService Service { get; }

        public IEnumerable<ICustomerData> Customers
        {
            get
            {
                IEnumerable<ICustomerData> customers = Service.GetAllCustomers();
                return customers;
            }
        }

        public ICustomerModelView CreateCustomer(int customer_id, string name, string Surname)
        {
            return null;//CustomerModelView(customer_id, name, Surname);
        }
    }
}
