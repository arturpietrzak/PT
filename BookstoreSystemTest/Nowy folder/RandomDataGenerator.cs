using BookstoreSystem.Data;
using System;
using System.Collections.Generic;

namespace BookstoreSystemTest.Generators
{
    public class RandomDataGenerator : IGenerator
    {
        private Random rnd = new Random();
        public DataContext Generate()
        {
            DataContext context = RandomContent();

            return context;
        }

        private DataContext RandomContent()
        {
            DataContext context = new DataContext();

            // random books
            string[] firstPart =
            {
                "The story of ",
                "An Unexpected Journey of",
                "Sad history of ",
                "The haunting of ",
            };

            string[] secondPart =
            {               
                "amazing ",
                "short ",
                "brave ",
                "scary "
            };

            string[] thirPart =
            {               
                "amazing ",
                "short ",
                "brave ",
                "scary "
            };

            for (int i = 0; i < 10; i++)
            {
                string title = firstPart[rnd.Next(0, 4)] + secondPart[rnd.Next(0, 4)] + thirPart[rnd.Next(0, 4)];
                context.books.Add(new Book(i, title, rnd.Next(1, 500), Convert.ToDouble(rnd.Next(1, 5000)) / 100, Genre.thriller));
            }

            // random clients
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
                context.customers.Add(new Customer(i, firstNames[rnd.Next(0, 20)], lastNames[rnd.Next(0, 20)]));
            }

            // random states
            for (int i = 0; i < 10; i++)
            {
                // random chance of book not having a state
                if (rnd.Next(0, 4) == 3)
                {
                    continue;
                }
                context.states.Add(new State(context.books[i], rnd.Next(0, 100)));
            }

            // random events
            for (int i = 0; i < 5; i++)
            {
                // 50 / 50 chance on purchase of return event
                if (rnd.Next(0, 2) == 1)
                {
                    context.events.Add(new EventPurchase
                        (context.states[rnd.Next(0, context.states.Count)],
                        context.customers[rnd.Next(0, context.customers.Count)])
                        );   
                } 
                else
                {
                    context.events.Add(new EventReturn
                        (context.states[rnd.Next(0, context.states.Count)],
                        context.customers[rnd.Next(0, context.customers.Count)])
                        );
                }
            }

            return context;
        }
    }
}
