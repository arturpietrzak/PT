using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.API
{
    public interface ICustomerService
    {
        // Create
        bool AddCustomer(int customer_id, String name, String surname);
        // Read
        ICollection<ICustomerData> GetAllCustomers();
        ICollection<ICustomerData> GetCustomersByCredentials(String name, String surname); // multiple people can have the same name and surname
        ICustomerData GetCustomerById(int id);
        // Update
        bool UpdateCustomer(int customer_id, String name, String surname);
        // Delete
        bool DeleteCustomer(int customer_id);
    }
}
