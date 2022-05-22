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
    }
}
