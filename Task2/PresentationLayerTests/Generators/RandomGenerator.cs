using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.API;

namespace PresentationLayerTests
{
    internal class RandomGenerator : IGenerator
    {
        private Random rnd = new Random();

        TestBookModel bookModel;
        TestCustomerModel customerModel;
        TestPurchaseModel purchaseModel;
        TestStateModel stateModel;
        NavigationModel navigationModel;

        public RandomGenerator()
        {
            bookModel = new TestBookModel();
            customerModel = new TestCustomerModel();
            purchaseModel = new TestPurchaseModel();
            stateModel = new TestStateModel();
            navigationModel = new NavigationModel();

            string[] titles =
            {
                "Da Vinci Code",
                "Harry Potter and the Deathly Hallows",
                "Twilight",
                "Lost Symbol",
                "New Moon",
                "Eclipse",
                "Lovely Bones",
                "Digital Fortress",
                "Breaking Dawn",
                "One Day",
            };

            for (int i = 0; i < 10; i++)
            {
                bookModel.AddBook(i, titles[rnd.Next(0, 10)], rnd.Next(5, 500), rnd.Next(0, 50));
            }

            string[] firstNames =
            {
                "James",
                "Mary",
                "Robert",
                "Patricia",
                "John",
                "Jennifer",
                "Michael",
                "Linda",
                "William",
                "Elizabeth",
                "David",
                "Barbara",
                "Richard",
                "Susan",
                "Joseph",
                "Jessica",
                "Thomas",
                "Sarah",
                "Charles",
                "Karen",
            };

            string[] lastNames =
            {
                "Smith",
                "Johnson",
                "Williams",
                "Jones",
                "Brown",
                "Davis",
                "Miller",
                "Wilson",
                "Moore",
                "Taylor",
                "Anderson",
                "Thomas",
                "Jackson",
                "White",
                "Harris",
                "Martin",
                "Thompson",
                "Garcia",
                "Martinez",
                "Robinson",
            };

            for (int i = 0; i < 10; i++)
            {
                customerModel.AddCustomer(i, firstNames[rnd.Next(0, 20)], lastNames[rnd.Next(0, 20)]);
            }
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
