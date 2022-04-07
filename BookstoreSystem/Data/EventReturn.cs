using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreSystem.Data
{
    public class EventReturn : Event
    {
        public EventReturn(State _state, Customer _customer) 
            : base(_state, _customer)
        { }
    }
}
