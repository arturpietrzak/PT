namespace BookstoreSystem.Data.API
{
    public interface IEvent
    {
        public IState State { get ; }
        public ICustomer Customer { get ; }
        public DateTime EventDate { get ; }
    }
}
