using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.API;
using ServiceLayer.API;

namespace PresentationLayer
{
    internal class PurchaseModelData : IPurchaseModelData
    {
        public PurchaseModelData(IPurchaseService service)
        {
            Service = service;
        }

        public IPurchaseService Service { get; }

        public IEnumerable<IPurchaseData> Purchases
        {
            get
            {
                IEnumerable<IPurchaseData> purchases = Service.GetAllPurchases();
                return purchases;
            }
        }

        public IPurchaseModelView CreatePurchase(int state_id, int customer_id, DateTime purchase_date)
        {
            return null;//new PurchaseModelView(state_id, customer_id, purchase_date);
        }
    }
}
