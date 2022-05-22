using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.API;
using PresentationLayer.API;

namespace PresentationLayer
{
    internal class StateModel : IStateModel
    {
        public StateModel(IStateService service)
        {
            Service = service;
        }

        public IStateModelData Transform(IStateData data)
        {
            if (data == null)
            {
                return null;
            }

            return new StateModelData(
                data.State_Id,
                data.Book_Id,
                data.Amount);
        }

        public IStateModelData GetStateByBookId(int id)
        {
            return Transform(Service.GetStateByBookId(id));
        }

        public IStateService Service { get; }
    }
}
