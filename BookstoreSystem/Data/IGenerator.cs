using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreSystem.Data.API;

namespace BookstoreSystem.Data
{
    public interface IGenerator
    {
        DataLayerAbstractAPI Generate();

    }
}
