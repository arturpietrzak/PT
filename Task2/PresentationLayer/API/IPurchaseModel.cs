using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.API;

namespace PresentationLayer.API
{
    public interface IPurchaseModel
    {
        IPurchaseModelData Transform(IPurchaseData data);
        IPurchaseService Service { get; }
        ICollection<IPurchaseModelData> GetAllPurchasesByCustomer(int id);
        ICollection<IPurchaseModelData> GetAllPurchases();
        IPurchaseModelData GetPurchaseByID(String id);
        bool HandlePurchase(int customer_id, int book_id, int state_id);
    }
}
