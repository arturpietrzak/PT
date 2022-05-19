using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.API;
using ServiceLayer.API;

namespace PresentationLayer.Model
{
    internal class PurchaseModelData : IPurchaseModelData
    {
        IPurchaseService Service { get; }

        public PurchaseModelData(IPurchaseService service)
        {
            Service = service;
        }

        IEnumerable<IPurchaseData> Purchase
        {
            get
            {
                IEnumerable<IPurchaseData> purchases = Service.GetAllPurchases();
                return purchases;
            }
        }

        IPurchaseModelView CreatePurchase(int state_id, int customer_id, DateTime purchase_date)
        {
            return new PurchaseModelView(state_id, customer_id, purchase_date );
        }
    }
}
