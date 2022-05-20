using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.API
{
    public abstract class IStateData
    {
        public abstract int State_Id { get; }
        public abstract int Book_Id { get; }
        public abstract int Amount { get; }
    }
}
