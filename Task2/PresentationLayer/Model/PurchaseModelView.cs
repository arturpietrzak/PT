using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.API;

namespace PresentationLayer.Model
{
    internal class PurchaseModelView : IPurchaseModelView
    {
        int State_Id { get; }
        int Customer_id { get; }
        DateTime Purchase_date { get; }

        public PurchaseModelView(int state_Id, int customer_id, DateTime purchase_date)
        {
            State_Id = state_Id;
            Customer_id = customer_id;
            Purchase_date = purchase_date;
        }
    }
}
