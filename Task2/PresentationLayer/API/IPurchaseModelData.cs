using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.API;

namespace PresentationLayer.API
{
    interface IPurchaseModelData
    {
        IPurchaseService Service { get; }
        IEnumerable<IPurchaseData> Book { get; }
        IPurchaseModelView CreatePurchase(int state_id, int customer_id, DateTime purchase_date);
    }
}
