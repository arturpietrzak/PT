using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.API;

namespace PresentationLayer.API
{
    public interface IPurchaseModelData
    {
        String Purchase_Id { get; }
        int State_Id { get; }
        int Customer_id { get; }
        DateTime Purchase_date { get; }
    }
}
