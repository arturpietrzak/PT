using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.API;
using DataLayer.API;

namespace ServiceLayer.Implementations
{
    internal class StateService : IStateService
    {
        private IDataLayerAPI dataLayer;

        public StateService(IDataLayerAPI dataLayer)
        {
            this.dataLayer = dataLayer;
        }

        // Create
        public bool AddState(int state_id, int book_id, int amount)
        {
            IBook book = dataLayer.GetBook(book_id);

            if (book == null)
            {
                return false;
            }

            return dataLayer.CreateState(state_id, dataLayer.GetBook(book_id), amount);
        }
        // Read
        public ICollection<IStateData> GetAllStates()
        {
            List<IState> states = dataLayer.GetAllStates().ToList();
            List<IStateData> stateDatas = new List<IStateData>();

            foreach (var state in states)
            {
                stateDatas.Add(new StateData(state.Id, state.Book.Id, state.Amount));
            }

            return stateDatas;
        }
        public IStateData GetStateByBookId(int book_id)
        {
            List<IState> states = dataLayer.GetAllStates().ToList();

            foreach (var state in states)
            {
                if (state.Book.Id == book_id)
                {
                    return new StateData(state.Id, state.Book.Id, state.Amount);
                }
            }

            return null;
        }
        public IStateData GetStateByStateId(int state_id)
        {
            IState state = dataLayer.GetState(state_id);

            if (state == null)
            {
                return null;
            }

            return new StateData(state.Id, state.Book.Id, state.Amount);
        }
        // Update
        public bool UpdateStateAmount(int state_id, int amount)
        {
            return dataLayer.UpdateStateAmount(state_id, amount);
        }
        // Delete
        public bool DeleteState(int state_id)
        {
            return dataLayer.DeleteState(state_id);
        }
    }
}
