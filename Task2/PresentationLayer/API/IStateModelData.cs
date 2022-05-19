using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.API;

namespace PresentationLayer.API
{
    interface IStateModelData
    {
        IStateService Service { get; }
        IEnumerable<IStateData> State { get; }
        IStateModelView CreateState(int state_id, int book_id, int amount);
    }
}
