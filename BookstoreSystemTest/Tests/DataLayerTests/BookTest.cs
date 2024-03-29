﻿using System;
using BookstoreSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookstoreSystemTest.Generators;
using BookstoreSystem.Data.API;

namespace BookstoreSystemTest.DataLayerTests
{
    [TestClass]
    public class BookTest
    {
        private DataLayerAbstractAPI dataLayer = DataLayerAbstractAPI.CreateSimpleAPIImplementation();
        private DataLayerGenerator generator = new DataLayerGenerator();
        private RandomDataGenerator randomGenerator = new RandomDataGenerator();

        [TestInitialize]
        public void Startup()
        {
            dataLayer = DataLayerAbstractAPI.CreateSimpleAPIImplementation();
        }

        [TestMethod]

        public void TestGetBook()
        {
            IBook book1 = new TBook(321, "test book", 300, 20.99, Genre.romance);

            Assert.AreEqual(book1.Id, 321);
            Assert.AreEqual(book1.Name, "test book");
            Assert.AreEqual(book1.Pages, 300);
            Assert.AreEqual(book1.Price, 20.99);
            Assert.AreEqual(book1.Genre, Genre.romance);
        }

        [TestMethod]
        public void TestBookAddition()
        {
            dataLayer = generator.Generate();

            dataLayer.AddBook(new TBook(321, "test book", 300, 20.99, Genre.romance));
            Assert.AreEqual(dataLayer.BookById(321).Name, "test book");

            dataLayer.AddCustomer(new TCustomer(100, "Tom", "Platz"));
            Assert.AreEqual(dataLayer.CustomerById(100).Name, "Tom");

            dataLayer.AddState(new TState(dataLayer.BookById(321), 100));
            Assert.AreEqual(dataLayer.GetStateByBook(dataLayer.BookById(321)).Amount, 100);
        }

        [TestMethod]
        public void TestBookDeletion()
        {
            dataLayer = generator.Generate();

            // deleted data should not be accessible
            dataLayer.DeleteBook(dataLayer.BookById(1));
            Assert.ThrowsException<NullReferenceException>(() => dataLayer.BookById(1).Id);

            dataLayer.DeleteBook(dataLayer.BookById(6));
            Assert.ThrowsException<NullReferenceException>(() => dataLayer.BookById(6).Id);
        }

        [TestMethod]
        public void TestChangeBook()
        {
            dataLayer = generator.Generate();

            IBook b = new TBook(321, "Test book", 100, 5.99, Genre.guide);
            dataLayer.AddBook(b);

            Assert.AreEqual(dataLayer.BookById(321).Name, "Test book");
            dataLayer.BookById(321).Name = "Guide book";
            Assert.AreEqual(dataLayer.BookById(321).Name, "Guide book");
        }


        [TestMethod]
        public void TestBookOperationsWithRandomGeneratedData()
        {
            dataLayer = randomGenerator.Generate();

            // check deletion of data - deleted data should not be accessible
            dataLayer.DeleteBook(dataLayer.BookById(5));
            Assert.ThrowsException<NullReferenceException>(() => dataLayer.BookById(5).Id);

            // check addition of data
            dataLayer.AddBook(new TBook(321, "test book", 300, 20.99, Genre.romance));
            Assert.AreEqual(dataLayer.BookById(321).Name, "test book");

            Assert.ThrowsException<Exception>(() => dataLayer.AddBook(dataLayer.BookById(321)));
        }
    }
}
