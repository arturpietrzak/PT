using System.Collections;
using System.Collections.Generic;
using DataLayer.API;

namespace DataLayer
{
    internal class DataContext
    {
        public List<IBook> books = new List<IBook>();
        public List<ICustomer> customers = new List<ICustomer>();
        public List<IEvent> events = new List<IEvent>();
        public List<IState> states = new List<IState>();
    }
}
