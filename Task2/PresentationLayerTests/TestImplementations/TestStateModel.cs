using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.API;

namespace PresentationLayerTests
{
    internal class TestStateModel : IStateModel
    {
        IList<IStateModelData> data;
        public TestStateModel()
        {
            data = new List<IStateModelData>();
        }

        public IStateModelData GetStateByBookId(int id)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Book_Id == id)
                {
                    return data[i];
                }
            }

            return null;
        }
        public bool UpdateStateAmount(int book_id, int newAmount)
        {
            if (newAmount < 0 || GetStateByBookId(book_id) == null)
            {
                return false;
            }

            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Book_Id == book_id)
                {
                    data[i].Amount = newAmount;
                }
            }

            return true;
        }

        private class TestStateModelData : IStateModelData
        {
            public int State_Id { get; set; }
            public int Book_Id { get; set; }
            public int Amount { get; set; }

            public TestStateModelData(int state_Id, int book_Id, int amount)
            {
                State_Id = state_Id;
                Book_Id = book_Id;
                Amount = amount;
            }
        }
    }
}
