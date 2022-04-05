using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;


namespace DataLayer 
{ 
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Page_number { get; set; }
        public float Price { get; set; }

       
        public Book(string title, string author, int page_number, float price)
        {
            Title = title;
            Author = author;
            Page_number = page_number;
            Price = price;
        }
    }
}
