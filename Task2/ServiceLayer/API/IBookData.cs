using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.API
{
    public abstract class IBookData
    {
        public abstract int Book_Id { get; }
        public abstract string Name { get; }
        public abstract int Pages { get; }
        public abstract double Price { get; }
    }
}
