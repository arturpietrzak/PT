using DataLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.API;

namespace ServiceLayer.API
{
    public abstract class IPurchaseService
    {
        // Create
        public abstract bool HandlePurchase(int customer_id, int book_id, int state_id);
        // Read
        public abstract IPurchaseData GetPurchaseByID(String purchase_id);

        public abstract ICollection<IPurchaseData> GetAllPurchases();
        public abstract ICollection<IPurchaseData> GetAllPurchasesByCustomer(int customer_id);

        public static IPurchaseService CreateAPI()
        {
            return new API(IDataLayerAPI.CreateAPIUsingSQL());
        }
        public static IPurchaseService CreateTestAPI()
        {
            return new API(IDataLayerAPI.CreateTestAPI());
        }

        internal class API : IPurchaseService
        {
            private IDataLayerAPI dataLayer;

            public API(IDataLayerAPI dataLayer)
            {
                this.dataLayer = dataLayer;
                dataLayer.Connect();
            }

            // Create - after purchase should reduce amount of book in state
            public override bool HandlePurchase(int customer_id, int book_id, int state_id)
            {
                IBook book = dataLayer.GetBook(book_id);
                if (book == null)
                {
                    return false;
                }

                IState state = dataLayer.GetStateForBook(book);
                if (state == null || state.Amount <= 0)
                {
                    return false;
                }

                ICustomer customer = dataLayer.GetCustomer(customer_id);
                if (customer == null)
                {
                    return false;
                }

                dataLayer.CreateEvent(state, customer);
                return true;
            }
            // Read
            public override IPurchaseData GetPurchaseByID(String purchase_id)
            {
                IEvent purchase = dataLayer.GetEventById(purchase_id);

                if (purchase == null)
                {
                    return null;
                }

                return new PurchaseData(purchase.Id, purchase.State != null ? purchase.State.Id : -1, purchase.Customer != null ? purchase.Customer.Id : -1, purchase.EventDate);

            }

            public override ICollection<IPurchaseData> GetAllPurchases()
            {
                List<IEvent> events = dataLayer.GetAllEvents().ToList();
                List<IPurchaseData> purchaseDatas = new List<IPurchaseData>();

                foreach (var evt in events)
                {
                    purchaseDatas.Add(new PurchaseData(evt.Id, evt.State != null ? evt.State.Id : -1, evt.Customer != null ? evt.Customer.Id : -1, evt.EventDate));
                }

                return purchaseDatas;
            }
            public override ICollection<IPurchaseData> GetAllPurchasesByCustomer(int customer_id)
            {
                List<IEvent> events = dataLayer.GetAllEvents().ToList();
                List<IPurchaseData> purchaseDatas = new List<IPurchaseData>();

                foreach (var evt in events)
                {
                    if (evt.Customer != null && evt.Customer.Id == customer_id)
                    {
                        purchaseDatas.Add(new PurchaseData(evt.Id, evt.State != null ? evt.State.Id : -1, evt.Customer.Id, evt.EventDate));
                    }
                }

                return purchaseDatas;
            }
        }
    }
}
