using DataLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.API
{
    public abstract class IPurchaseService
    {
        // Create
        public abstract bool HandlePurchase(int customer_id, int book_id, int state_id);
        // Read
        public abstract ICollection<IPurchaseData> GetAllPurchases();
        public abstract ICollection<IPurchaseData> GetAllPurchasesByCustomer(int customer_id);

        public static IPurchaseService CreateAPI()
        {
            return new API(IDataLayerAPI.CreateAPIUsingSQL());
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
                return dataLayer.UpdateStateAmount(state_id, state.Amount - 1);
            }
            // Read
            public override ICollection<IPurchaseData> GetAllPurchases()
            {
                List<IEvent> events = dataLayer.GetAllEvents().ToList();
                List<IPurchaseData> purchaseDatas = new List<IPurchaseData>();

                foreach (var evt in events)
                {
                    purchaseDatas.Add(new PurchaseData(evt.State.Id, evt.Customer.Id, evt.EventDate));
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
                        purchaseDatas.Add(new PurchaseData(evt.State != null ? evt.State.Id : -1, evt.Customer.Id, evt.EventDate));
                    }
                }

                return purchaseDatas;
            }
        }
    }
}
