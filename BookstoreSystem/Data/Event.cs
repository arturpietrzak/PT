using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreSystem.Data
{
    public abstract class Event
    {
        private State state;
        private Customer customer;
        private DateTime eventDate;

        protected Event(State _state, Customer _client)
        {
            this.state = _state;
            this.customer = _client;
            this.eventDate = DateTime.Now;
        }

        public State State { get { return this.state; } }
        public Customer Customer { get { return this.customer; } } 
        protected DateTime EventDate { get { return this.eventDate; } }
    }
}
