using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.API
{
    internal class PurchaseData : IPurchaseData
    {
        public PurchaseData(int state_Id, int customer_id, DateTime purchase_date)
        {
            State_Id = state_Id;
            Customer_id = customer_id;
            Purchase_date = purchase_date;
        }

        public int State_Id { get; }
        public int Customer_id { get; }
        public DateTime Purchase_date { get; }
    }
}
