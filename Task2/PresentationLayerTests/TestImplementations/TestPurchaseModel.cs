using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.API;

namespace PresentationLayerTests
{
    internal class TestPurchaseModel : IPurchaseModel
    {
        IList<IPurchaseModelData> data;
        public TestPurchaseModel()
        {
            data = new List<IPurchaseModelData>();
        }

        public ICollection<IPurchaseModelData> GetAllPurchasesByCustomer(int id)
        {
            List<IPurchaseModelData> purchasesByCustomer = new List<IPurchaseModelData>();

            foreach (var purchase in data)
            {
                if (purchase.Customer_id == id)
                {
                    purchasesByCustomer.Add(purchase);
                }
            }
            return purchasesByCustomer;
        }
        public ICollection<IPurchaseModelData> GetAllPurchases()
        {
            return data;
        }
        public IPurchaseModelData GetPurchaseByID(String id)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Purchase_Id == id)
                {
                    return data[i];
                }
            }

            return null;
        }
        public bool HandlePurchase(int customer_id, int book_id, int state_id)
        {
            data.Add(new TestPurchaseModelData(Guid.NewGuid().ToString(), state_id, customer_id, DateTime.Now));
            return true;
        }


        private class TestPurchaseModelData : IPurchaseModelData
        {
            public String Purchase_Id { get; set; }
            public int State_Id { get; set; }
            public int Customer_id { get; set; }
            public DateTime Purchase_date { get; set; }

            public TestPurchaseModelData(string purchase_Id, int state_Id, int customer_id, DateTime purchase_date)
            {
                Purchase_Id = purchase_Id;
                State_Id = state_Id;
                Customer_id = customer_id;
                Purchase_date = purchase_date;
            }
        }
    }
}
