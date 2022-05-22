using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.API;

namespace PresentationLayer.API
{
    public interface IStateModel
    {
        IStateModelData Transform(IStateData data);
        IStateService Service { get; }
        IStateModelData GetStateByBookId(int id);
    }
}
