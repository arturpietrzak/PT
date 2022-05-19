using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.API
{
    public interface IPurchaseService
    {
        // Create
        bool HandlePurchase(int customer_id, int book_id, int state_id);
        // Read
        ICollection<IPurchaseData> GetAllPurchases();
        ICollection<IPurchaseData> GetAllPurchasesByCustomer(int customer_id);
    }
}
