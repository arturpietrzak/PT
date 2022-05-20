using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.API;

namespace ServiceLayer
{
    internal class StateData : IStateData
    {
        public StateData(int state_Id, int book_Id, int amount)
        {
            State_Id = state_Id;
            Book_Id = book_Id;
            Amount = amount;
        }

        public override int State_Id { get; }
        public override int Book_Id { get; }
        public override int Amount { get; }
    }
}
