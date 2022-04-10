using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreSystem.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace BookstoreSystem.UnitTests
{
    [TestClass]
    public class SpecifiedGeneratorTest

    {
        private DataContext dataContext = new DataContext();
        private DataRepository repository = new DataRepository();


       /* public void NotNull()
        {
            Assert.IsNotNull(repository.AllBooks);
            Assert.IsNotNull(value: repository.AllCustomers);
            Assert.IsNotNull(value :repository.AllStates);

        }*/
       [TestMethod]
        public void Equal()
        {
            Assert.AreEqual(dataContext.books.Count, 3+5+6);
            Assert.AreEqual(dataContext.customers, 3);
            Assert.AreEqual(dataContext.states, 3);
        }
    }
}
