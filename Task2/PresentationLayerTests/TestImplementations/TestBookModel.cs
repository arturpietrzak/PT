using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresentationLayer.API;

namespace PresentationLayerTests
{
    internal class TestBookModel : IBookModel
    {
        IList<IBookModelData> data;
        public TestBookModel()
        {
            data = new List<IBookModelData>();
        }

        public ICollection<IBookModelData> GetAllBooks()
        {
            return data;
        }

        public bool AddBook(int id, String name, int pages, double price)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Book_Id == id)
                {
                    return false;
                }
            }

            data.Add(new TestBookModelData(id, name, pages, price));

            return true;
        }

        public bool UpdateBook(int id, String name, int pages, double price)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Book_Id == id)
                {
                    data[i].Name = name;
                    data[i].Pages = pages;
                    data[i].Price = price;
                    return true;
                }
            }

            return false;
        }

        public bool DeleteBook(int id)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Book_Id == id)
                {
                    data.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        private class TestBookModelData : IBookModelData
        {
            public int Book_Id { get; set; }
            public string Name { get; set; }
            public int Pages { get; set; }
            public double Price { get; set; }

            public TestBookModelData(int book_Id, string name, int pages, double price)
            {
                Book_Id = book_Id;
                Name = name;
                Pages = pages;
                Price = price;
            }
        }
    }
}
