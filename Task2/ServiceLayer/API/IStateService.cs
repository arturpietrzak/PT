using DataLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.API
{
    public abstract class IStateService
    {
        // Create
        public abstract bool AddState(int state_id, int book_id, int amount);
        // Read
        public abstract ICollection<IStateData> GetAllStates();
        public abstract IStateData GetStateByBookId(int book_id);
        public abstract IStateData GetStateByStateId(int state_id);
        // Update
        public abstract bool UpdateStateAmount(int state_id, int amount);
        // Delete
        public abstract bool DeleteState(int state_id);

        public static IStateService CreateAPI()
        {
            return new API(IDataLayerAPI.CreateAPIUsingSQL());
        }

        internal class API : IStateService
        {
            private IDataLayerAPI dataLayer;

            public API(IDataLayerAPI dataLayer)
            {
                this.dataLayer = dataLayer;
                dataLayer.Connect();
            }

            // Create
            public override bool AddState(int state_id, int book_id, int amount)
            {
                IBook book = dataLayer.GetBook(book_id);

                if (book == null)
                {
                    return false;
                }

                return dataLayer.CreateState(state_id, dataLayer.GetBook(book_id), amount);
            }
            // Read
            public override ICollection<IStateData> GetAllStates()
            {
                List<IState> states = dataLayer.GetAllStates().ToList();
                List<IStateData> stateDatas = new List<IStateData>();

                foreach (var state in states)
                {
                    stateDatas.Add(new StateData(state.Id, state.Book.Id, state.Amount));
                }

                return stateDatas;
            }
            public override IStateData GetStateByBookId(int book_id)
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
            public override IStateData GetStateByStateId(int state_id)
            {
                IState state = dataLayer.GetState(state_id);

                if (state == null)
                {
                    return null;
                }

                return new StateData(state.Id, state.Book.Id, state.Amount);
            }
            // Update
            public override bool UpdateStateAmount(int state_id, int amount)
            {
                return dataLayer.UpdateStateAmount(state_id, amount);
            }
            // Delete
            public override bool DeleteState(int state_id)
            {
                return dataLayer.DeleteState(state_id);
            }
        }
    }
}
