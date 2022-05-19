using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.API
{
    public interface IPurchaseData
    {
        int State_Id { get; }
        int Customer_id { get; }
        DateTime Purchase_date { get; }
    }
}
