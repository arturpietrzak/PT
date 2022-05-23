using System;
using System.Collections.Generic;
using ServiceLayer.API;

namespace PresentationLayer.API
{
    internal class CustomerModel : ICustomerModel
    {
        public CustomerModel(ICustomerService service)
        {
            Service = service;
        }

        public ICustomerModelData Transform(ICustomerData data)
        {
            if (data == null)
            {
                return null;
            }
            return new CustomerModelData(data.Customer_Id, data.Name, data.Surname);
        }

        public ICustomerService Service { get; set; }

        public ICollection<ICustomerModelData> GetAllCustomers()
        {
            ICollection<ICustomerData> serviceData = Service.GetAllCustomers();
            IList<ICustomerModelData> modelData = new List<ICustomerModelData>();

            foreach (var servDataElement in serviceData)
            {
                modelData.Add(Transform(servDataElement));
            }

            return modelData;
        }

        public bool AddCustomer(int id, String name, String surname)
        {
            return Service.AddCustomer(id, name, surname); 
        }
        public bool UpdateCustomer(int id, String name, String surname)
        {
            return Service.UpdateCustomer(id, name, surname);
        }
        public bool DeleteCustomer(int id)
        {
            return Service.DeleteCustomer(id);
        }

    }
}
