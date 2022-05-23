using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.API
{
    public interface IGenerator
    {
        NavigationModel GetNavigationModel();
        IBookModel GetBookModel();
        ICustomerModel GetCustomerModel();
        IPurchaseModel GetPurchaseModel();
        IStateModel GetStateModel();
    }
}
