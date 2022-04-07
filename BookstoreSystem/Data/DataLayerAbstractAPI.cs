using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreSystem.Data.API
{
    public abstract class DataLayerAbstractAPI
    {
        public DataContext context;
        public abstract void Connect();

        // factory method
        public static DataLayerAbstractAPI CreateSimpleAPIImplementation()
        {
            return new SimpleAPIImplementation();
        }


        private class SimpleAPIImplementation : DataLayerAbstractAPI
        {
            public SimpleAPIImplementation()
            {
                this.context = new DataContext();
            }

            public override void Connect()
            {
                // some connection, maybe some generated values?
            }
        }
    }


}
