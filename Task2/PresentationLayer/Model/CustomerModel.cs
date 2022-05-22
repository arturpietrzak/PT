using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.API;
using ServiceLayer.API;

namespace PresentationLayer
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

        public ICustomerService Service { get; }

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

    }
}
