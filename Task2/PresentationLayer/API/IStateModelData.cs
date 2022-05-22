using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.API;

namespace PresentationLayer.API
{
    public interface IStateModelData
    {
        int State_Id { get; }
        int Book_Id { get; }
        int Amount { get; }
    }
}
