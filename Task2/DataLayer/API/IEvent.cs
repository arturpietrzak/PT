using System;

namespace DataLayer.API
{
    public interface IEvent
    {
        IState State { get ; }
        ICustomer Customer { get ; }
        DateTime EventDate { get; set; }
    }
}
