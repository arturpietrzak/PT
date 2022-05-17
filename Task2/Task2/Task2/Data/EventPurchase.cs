using BookstoreSystem.Data.API;

namespace BookstoreSystem.Data
{
    internal class EventPurchase : IEvent
    {
        private IState state;
        private ICustomer customer;
        private DateTime eventDate;
        public EventPurchase(IState _state, ICustomer _client)
        {
            this.state = _state;
            this.customer = _client;
            this.eventDate = DateTime.Now;
        }

        public IState State { get { return this.state; } }
        public ICustomer Customer { get { return this.customer; } }
        public DateTime EventDate { get { return this.eventDate; } }
    }
}
