using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.API
{
    public interface ICustomerData
    {
        int Customer_Id { get; }
        string Name { get; }
        string Surname { get; }
    }
}
