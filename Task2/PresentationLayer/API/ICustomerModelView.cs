using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.API
{
    public interface ICustomerModelView
    {
        int Customer_Id { get; }
        String Name { get; }
        String Surname { get; }
    }
}
