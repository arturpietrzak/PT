using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.API;

namespace PresentationLayer
{
    internal class StateModelData : IStateModelData
    {
        public int State_Id { get; }
        public int Book_Id { get; }
        public int Amount { get; }

        public StateModelData(int state_Id, int book_Id, int amount)
        {
            State_Id = state_Id;
            Book_Id = book_Id;
            Amount = amount;
        }
    }
}
