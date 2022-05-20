using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.API;
using DataLayer.API;

namespace ServiceLayer
{
    internal class CustomerService : ICustomerService
    {
        private IDataLayerAPI dataLayer;

        public CustomerService(IDataLayerAPI dataLayer)
        {
            this.dataLayer = dataLayer;
        }

        // Create
        public override bool AddCustomer(int customer_id, String name, String surname)
        {
            return dataLayer.CreateCustomer(customer_id, name, surname);
        }
        // Read
        public override ICollection<ICustomerData> GetAllCustomers()
        {
            List<ICustomer> customers = dataLayer.GetAllCustomers().ToList();
            List<ICustomerData> customerDatas = new List<ICustomerData>();

            foreach (var customer in customers)
            {
                customerDatas.Add(new CustomerData(customer.Id, customer.Name, customer.Surname));
            }

            return customerDatas;
        }
        public override ICollection<ICustomerData> GetCustomersByCredentials(String name, String surname) // multiple people can have the same name and surname
        {
            List<ICustomer> customers = dataLayer.GetAllCustomers().ToList();
            List<ICustomerData> customerDatas = new List<ICustomerData>();

            foreach (var customer in customers)
            {
                if (customer.Name == name && customer.Surname == surname)
                {
                    customerDatas.Add(new CustomerData(customer.Id, customer.Name, customer.Surname)); 
                }
            }

            return customerDatas;
        }
        public override ICustomerData GetCustomerById(int id)
        {
            ICustomer customer = dataLayer.GetCustomer(id);

            if (customer == null)
            {
                return null;
            }

            return new CustomerData(customer.Id, customer.Name, customer.Surname);
        }
        // Update
        public override bool UpdateCustomer(int customer_id, String name, String surname)
        {
            return dataLayer.UpdateCustomer(customer_id, name, surname);
        }
        // Delete
        public override bool DeleteCustomer(int customer_id)
        {
            return dataLayer.DeleteCustomer(customer_id);
        }
    }
}
