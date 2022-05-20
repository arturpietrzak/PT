using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.API
{
    public abstract class ICustomerData
    {
        public abstract int Customer_Id { get; }
        public abstract string Name { get; }
        public abstract string Surname { get; }
    }
}
