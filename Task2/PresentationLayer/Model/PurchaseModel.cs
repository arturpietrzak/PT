using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.API;
using ServiceLayer.API;

namespace PresentationLayer
{
    internal class PurchaseModel : IPurchaseModel
    {
        public PurchaseModel(IPurchaseService service)
        {
            Service = service;
        }

        public IPurchaseModelData Transform(IPurchaseData data)
        {
            if (data == null)
            {
                return null;
            }

            return new PurchaseModelData(data.Purchase_Id, data.State_Id, data.Customer_id, data.Purchase_date);
        }
        public IPurchaseService Service { get; }

        public ICollection<IPurchaseModelData> GetAllPurchasesByCustomer(int id)
        {
            ICollection<IPurchaseData> serviceData = Service.GetAllPurchasesByCustomer(id);
            IList<IPurchaseModelData> modelData = new List<IPurchaseModelData>();

            foreach (var servDataElement in serviceData)
            {
                modelData.Add(Transform(servDataElement));
            }

            return modelData;
        }

        public ICollection<IPurchaseModelData> GetAllPurchases()
        {
            ICollection<IPurchaseData> serviceData = Service.GetAllPurchases();
            IList<IPurchaseModelData> modelData = new List<IPurchaseModelData>();

            foreach (var servDataElement in serviceData)
            {
                modelData.Add(Transform(servDataElement));
            }

            return modelData;
        }

        public IPurchaseModelData GetPurchaseByID(String id)
        {
            return Transform(Service.GetPurchaseByID(id));
        }
    }
}
