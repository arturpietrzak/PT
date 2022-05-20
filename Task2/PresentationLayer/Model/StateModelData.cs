using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.API;
using PresentationLayer.API;

namespace PresentationLayer
{
    internal class StateModelData : IStateModelData
    {
        public StateModelData(IStateService service)
        {
            Service = service;
        }
        public IStateService Service { get; }
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
            return null;// new StateModelView(state_id, book_id, amount);
        }
    }
}
