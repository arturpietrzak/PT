using System;

namespace DataLayer.API
{
    public interface IEvent
    {
        String Id { get; }
        IState State { get ; }
        ICustomer Customer { get ; }
        DateTime EventDate { get; set; }
    }
}
