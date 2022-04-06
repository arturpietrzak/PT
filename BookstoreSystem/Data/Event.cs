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
        private Customer client;
        private DateTime eventDate;

        protected Event(State _state, Customer _client)
        {
            this.state = _state;
            this.client = _client;
            this.eventDate = DateTime.Now;
        }
    }
}
