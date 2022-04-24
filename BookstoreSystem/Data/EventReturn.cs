using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreSystem.Data
{
    internal class EventReturn : IEvent
    {
        private IState state;
        private ICustomer customer;
        private DateTime eventDate;

        public EventReturn(IState _state, ICustomer _client)
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
