using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.API
{
    internal class IStateModelView
    {
        int State_Id { get; }
        int Book_Id { get; }
        int Amount { get; }
    }
}
