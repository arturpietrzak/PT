using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.API
{
    public abstract class IPurchaseData
    {
        public abstract String Purchase_Id { get; }
        public abstract int State_Id { get; }
        public abstract int Customer_id { get; }
        public abstract DateTime Purchase_date { get; }
    }
}
