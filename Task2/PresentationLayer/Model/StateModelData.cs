using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.API;
using PresentationLayer.API;

namespace PresentationLayer.Model
{
    internal class StateModelData : IStateModelData
    {
        public IStateService Service { get; }

        public StateModelData(IStateService service)
        {
            Service = service;
        }
        public IEnumerable<IStateData> State
        {
            get
            {
                IEnumerable<IStateData> states = Service.GetAllStates();
                return states;
            }
        }


        public IStateModelView CreateState(int state_id, int book_id, int amount)
        {
            return new StateModelView(state_id, book_id, amount);
        }
    }
}
