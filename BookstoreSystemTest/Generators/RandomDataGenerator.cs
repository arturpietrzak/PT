using BookstoreSystem.Data;
using System;
using System.Collections.Generic;
using BookstoreSystem.Data.API;

namespace BookstoreSystemTest.Generators
{
    public class RandomDataGenerator : IGenerator
    {
        private Random rnd = new Random();
        public DataLayerAbstractAPI Generate()
        {
            DataLayerAbstractAPI layer = RandomContent();

            return layer;
        }

        private DataLayerAbstractAPI RandomContent()
        {
            DataLayerAbstractAPI layer = DataLayerAbstractAPI.CreateSimpleAPIImplementation();

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
                layer.AddBook(new TBook(i, title, rnd.Next(1, 500), Convert.ToDouble(rnd.Next(1, 5000)) / 100, Genre.thriller));
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
                layer.AddCustomer(new TCustomer(i, firstNames[rnd.Next(0, 20)], lastNames[rnd.Next(0, 20)]));
            }

            // random states
            for (int i = 0; i < 10; i++)
            {
                // random chance of book not having a state
                if (rnd.Next(0, 4) == 3)
                {
                    continue;
                }
                layer.AddState(new TState(layer.AllBooks()[i], rnd.Next(0, 100)));
            }

            // random events
            for (int i = 0; i < 5; i++)
            {
                // 50 / 50 chance on purchase of return event
                if (rnd.Next(0, 2) == 1)
                {
                    layer.AddEvent(new TEventPurchase
                        (layer.AllStates()[rnd.Next(0, layer.AllStates().Count)],
                        layer.AllCustomers()[rnd.Next(0, layer.AllCustomers().Count)])
                        );   
                } 
                else
                {
                    layer.AddEvent(new TEventReturn
                        (layer.AllStates()[rnd.Next(0, layer.AllStates().Count)],
                        layer.AllCustomers()[rnd.Next(0, layer.AllCustomers().Count)])
                        );
                }
            }

            return layer;
        }
    }
}
