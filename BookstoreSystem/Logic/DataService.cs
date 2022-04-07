using BookstoreSystem.Logic;

namespace BookstoreSystem.logic
{
    public class DataService
    {
        private DataRepository dataRepository;

        public DataService (DataRepository _dataRepository)
        {
            this.dataRepository = _dataRepository;
        }
    }
}