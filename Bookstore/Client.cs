using DataLayer;
using System;

namespace DataLayer
{
	public class Client
	{
		public int Client_Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		

		public Client (int client_Id, string firstName, string lastName)
        {
			Client_Id = client_Id;
			FirstName = firstName;
			LastName = lastName;
 
        }
	}
}

