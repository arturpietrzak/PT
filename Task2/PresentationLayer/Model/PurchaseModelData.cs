﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.API;

namespace PresentationLayer
{
    internal class PurchaseModelData : IPurchaseModelData
    {
        public String Purchase_Id { get; }
        public int State_Id { get; }
        public int Customer_id { get; }
        public DateTime Purchase_date { get; }

        public PurchaseModelData(string purchase_Id, int state_Id, int customer_id, DateTime purchase_date)
        {
            Purchase_Id = purchase_Id;
            State_Id = state_Id;
            Customer_id = customer_id;
            Purchase_date = purchase_date;
        }
    }
}
