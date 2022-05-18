using System;
using DataLayer.API;

namespace DataLayer.Implementations
{
    internal class EventPurchase : IEvent
    {
        private int id;
        private IState state;
        private ICustomer customer;
        private DateTime eventDate;
        public EventPurchase(int id, IState _state, ICustomer _client)
        {
            this.id = id;
            state = _state;
            customer = _client;
            eventDate = DateTime.Now;
        }
        public int Id { get { return id; } }
        public IState State { get { return state; } }
        public ICustomer Customer { get { return customer; } }
        public DateTime EventDate
        {
            get { return eventDate; }
            set { eventDate = value; }
        }
    }
}
