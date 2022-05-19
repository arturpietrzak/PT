using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.API
{
    public interface IStateData
    {
        int State_Id { get; }
        int Book_Id { get; }
        int Amount { get; }
    }
}
