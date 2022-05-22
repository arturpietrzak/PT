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
        int Customer_Id { get; }
        string Name { get; }
        string Surname { get; }
    }
}
