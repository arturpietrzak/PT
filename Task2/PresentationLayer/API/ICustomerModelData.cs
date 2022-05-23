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
        int Customer_Id { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
    }
}
