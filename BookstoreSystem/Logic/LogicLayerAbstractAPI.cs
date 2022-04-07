using BookstoreSystem.Data.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreSystem.Logic.API
{
    public class LogicLayerAbstractAPI
    {
        public static LogicLayerAbstractAPI CreateLayer(DataLayerAbstractAPI? data = default)
        {
            return new LogicLayer(data == null ? DataLayerAbstractAPI.CreateSimpleAPIImplementation() : data);
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
