using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.API;

namespace PresentationLayerTests
{
    internal class StaticGenerator : IGenerator
    {
        TestBookModel bookModel;
        TestCustomerModel customerModel;
        TestPurchaseModel purchaseModel;
        TestStateModel stateModel;
        NavigationModel navigationModel;

        public StaticGenerator()
        {
            bookModel = new TestBookModel();
            customerModel = new TestCustomerModel();
            purchaseModel = new TestPurchaseModel();
            stateModel = new TestStateModel();
            navigationModel = new NavigationModel();

            // books
            bookModel.AddBook(1, "Test book 1", 200, 12);
            bookModel.AddBook(2, "Test book 2", 50, 15);
            bookModel.AddBook(3, "Test book 3", 150, 20);
            bookModel.AddBook(4, "Test book 4", 400, 30);

            // customers
            customerModel.AddCustomer(1, "Marek", "Jackowski");
            customerModel.AddCustomer(2, "Darek", "Wujkowski");
            customerModel.AddCustomer(3, "Tomek", "Krasinski");
            customerModel.AddCustomer(4, "Jacek", "Marlicki");
            customerModel.AddCustomer(5, "Wlodek", "Baranski");
            customerModel.AddCustomer(6, "Jozef", "Malarski");
            customerModel.AddCustomer(7, "Marcel", "Stefanski");
            customerModel.AddCustomer(8, "Patryk", "Blacharski");
        }

        public NavigationModel GetNavigationModel()
        {
            return navigationModel;

        }
        public IBookModel GetBookModel()
        {
            return bookModel;
        }
        public ICustomerModel GetCustomerModel()
        {
            return customerModel;
        }
        public IPurchaseModel GetPurchaseModel()
        {
            return purchaseModel;
        }
        public IStateModel GetStateModel()
        {
            return stateModel;
        }
    }
}
