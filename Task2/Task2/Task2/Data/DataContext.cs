using BookstoreSystem.Data.API;

namespace BookstoreSystem.Data
{
    internal class DataContext
    {
        // From UML:
        // catalog
        public List<IBook> books = new List<IBook>();
        // users
        public List<ICustomer> customers = new List<ICustomer>();
        // events
        public List<IEvent> events = new List<IEvent>();
        // states
        public List<IState> states = new List<IState>();
    }
}
