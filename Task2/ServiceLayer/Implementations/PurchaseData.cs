using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.API;

namespace ServiceLayer
{
    internal class PurchaseData : IPurchaseData
    {
        public PurchaseData(int state_Id, int customer_id, DateTime purchase_date)
        {
            State_Id = state_Id;
            Customer_id = customer_id;
            Purchase_date = purchase_date;
        }

        public override int State_Id { get; }
        public override int Customer_id { get; }
        public override DateTime Purchase_date { get; }
    }
}
