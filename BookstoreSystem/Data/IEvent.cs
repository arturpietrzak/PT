using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreSystem.Data
{
    public interface IEvent
    {
        public IState State { get ; }
        public ICustomer Customer { get ; }
        public DateTime EventDate { get ; }
    }
}
