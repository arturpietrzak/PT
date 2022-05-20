using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.API;

namespace PresentationLayer.API
{
    public interface ICustomerModelData
    {
        ICustomerService Service { get; }
        IEnumerable<ICustomerData> Customer { get; }
        ICustomerModelView CreateCustomer(int customer_id, String name, String Surname);
    }
}
