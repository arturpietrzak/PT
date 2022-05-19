using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.API;

namespace PresentationLayer.Model
{
    internal class StateModelView : IStateModelView
    {
        int State_Id { get; }
        int Book_Id { get; }
        int Amount { get; }

        public StateModelView(int state_Id, int book_Id, int amount)
        {
            State_Id = state_Id;
            Book_Id = book_Id;
            Amount = amount;
        }
    }
}
