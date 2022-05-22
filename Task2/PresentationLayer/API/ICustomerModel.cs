using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.API;

namespace PresentationLayer.API
{
    public interface ICustomerModel
    {
        ICustomerModelData Transform(ICustomerData data);
        ICustomerService Service { get; }
        ICollection<ICustomerModelData> GetAllCustomers();
        bool AddCustomer(int id, String name, String surname);
        bool UpdateCustomer(int id, String name, String surname);
        bool DeleteCustomer(int id);

    }
}
