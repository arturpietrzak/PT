using BookstoreSystem.Data.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreSystem.Logic.API
{
    public abstract class LogicLayerAbstractAPI
    {
        public static LogicLayerAbstractAPI CreateLayer(DataLayerAbstractAPI? data = default)
        {
            return new LogicLayer(data ?? DataLayerAbstractAPI.CreateSimpleAPIImplementation());
        }

        private class LogicLayer : LogicLayerAbstractAPI
        {
            public LogicLayer(DataLayerAbstractAPI data)
            {
                dataLayer = data;
                dataLayer.Connect();
            }
            private readonly DataLayerAbstractAPI dataLayer;
        }
    }
}
