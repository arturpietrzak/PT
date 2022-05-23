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
        IStateModelData GetStateByBookId(int id);
        bool UpdateStateAmount(int book_id, int newAmount);
    }
}
