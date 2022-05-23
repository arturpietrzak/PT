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
        String Purchase_Id { get; set; }
        int State_Id { get; set; }
        int Customer_id { get; set; }
        DateTime Purchase_date { get; set; }
    }
}
