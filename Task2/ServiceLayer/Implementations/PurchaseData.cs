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
        public PurchaseData(String purchase_Id, int state_Id, int customer_id, DateTime purchase_date)
        {
            this.Purchase_Id = purchase_Id;
            this.State_Id = state_Id;
            this.Customer_id = customer_id;
            this.Purchase_date = purchase_date;
        }

        public override String Purchase_Id { get; }
        public override int State_Id { get; }
        public override int Customer_id { get; }
        public override DateTime Purchase_date { get; }
    }
}
