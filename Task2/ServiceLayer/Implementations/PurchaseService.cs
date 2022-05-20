using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.API;
using DataLayer.API;

namespace ServiceLayer
{
    internal class PurchaseService : IPurchaseService
    {
        private IDataLayerAPI dataLayer;

        public PurchaseService(IDataLayerAPI dataLayer)
        {
            this.dataLayer = dataLayer;
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
                if (evt.Customer.Id == customer_id)
                {
                    purchaseDatas.Add(new PurchaseData(evt.State.Id, evt.Customer.Id, evt.EventDate));
                }
            }

            return purchaseDatas;
        }
    }
}
