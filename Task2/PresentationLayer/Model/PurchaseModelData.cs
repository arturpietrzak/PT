using System;
using System.Collections.Generic;
using PresentationLayer.API;

namespace PresentationLayer
{
    internal class PurchaseModelData : IPurchaseModelData
    {
        public String Purchase_Id { get; set; }
        public int State_Id { get; set; }
        public int Customer_id { get; set; }
        public DateTime Purchase_date { get; set; }

        public PurchaseModelData(string purchase_Id, int state_Id, int customer_id, DateTime purchase_date)
        {
            Purchase_Id = purchase_Id;
            State_Id = state_Id;
            Customer_id = customer_id;
            Purchase_date = purchase_date;
        }
    }
}
