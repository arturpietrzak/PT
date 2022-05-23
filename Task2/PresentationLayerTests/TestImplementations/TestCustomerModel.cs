using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.API;

namespace PresentationLayerTests
{
    internal class TestCustomerModel : ICustomerModel
    {
        IList<ICustomerModelData> data;

        public TestCustomerModel()
        {
            data = new List<ICustomerModelData>();

        }

        public ICollection<ICustomerModelData> GetAllCustomers()
        {
            return data;
        }
        public bool AddCustomer(int id, String name, String surname)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Customer_Id == id)
                {
                    return false;
                }
            }

            data.Add(new TestCustomerModelData(id, name, surname));

            return true;
        }
        public bool UpdateCustomer(int id, String name, String surname)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Customer_Id == id)
                {
                    data[i].Name = name;
                    data[i].Surname = surname;
                    return true;
                }
            }

            return false;
        }
        public bool DeleteCustomer(int id)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Customer_Id == id)
                {
                    data.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }
        public class TestCustomerModelData : ICustomerModelData
        {
            public int Customer_Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }

            public TestCustomerModelData(int customer_Id, string name, string surname)
            {
                Customer_Id = customer_Id;
                Name = name;
                Surname = surname;
            }
        }
    }
}
