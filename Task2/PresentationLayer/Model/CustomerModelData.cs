using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.API;
using ServiceLayer.API;

namespace PresentationLayer.Model
{
    internal class CustomerModelData : ICustomerModelData
    {
        public ICustomerService Service { get; }

        public CustomerModelData(ICustomerService service)
        {
            Service = service;
        }

        public IEnumerable<ICustomerData> Customer
        {
            get
            {
                IEnumerable<ICustomerData> customers = Service.GetAllCustomers();
                return customers;
            }
        }

        public ICustomerModelView CreateCustomer(int customer_id, string name, string Surname)
        {
            return new CustomerModelView(customer_id, name, Surname);
        }
    }
}
