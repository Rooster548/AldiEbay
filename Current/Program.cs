using System;
using System.Collections.Generic;
using System.IO;

using CAB201;

namespace UserInterfaceDemo {
	/// <summary>
	/// Demonstration program for UserInterface class.
	/// </summary>
	public class Program {
		private static List<Product> products = new List<Product>();
		private static List<Account> accounts = new List<Account>();
		static void Main( string[] args ) {
			MainMenu();
		}

		/// <summary>
		/// Displays a menu allowing user to choose an input operation to test.
		/// When user selects 4, program terminates.
		/// </summary>
		static void MainMenu() {
			const int REGISTER_ACCOUNT = 0, LOGIN = 1, EXIT = 2;
			const int REGISTER_ITEM = 0, LIST = 1, SEARCH = 2, PLACE_BID = 3, LIST_BID = 4, SELL_BID = 5, LOGOUT = 6;
			int option;
			///const int READ_INT = 0, READ_DOUBLE = 1, READ_BOOL = 2, GET_PASSWORD = 3, EXIT = 4;

			Console.WriteLine( "Welcome to the UserInterface Demo program." );
			accounts.Add(new Account("Matt", "pass"));
			int running = 1;
			int accountID;
			accountID = 0;
			while (running > 0)
			{
				switch (running)
				{
					case 0:

						break;

					case 1:
						 option = UserInterface.GetOption("Select one of the options",
					"Register", "Login", "Exit"
				);
						
						switch (option)
						{
							case REGISTER_ACCOUNT:
								string fullName, username, password, address;
								Account account = new Account();
								fullName = UserInterface.GetInput("Full name");
								account.setFullName(fullName);
								username = UserInterface.GetInput("Username");
								account.setUsername(username);
								password = UserInterface.GetPassword("Password");
								account.setPassword(password);
								address = UserInterface.GetInput("Address");
								account.setAddress(address);
								account.printDetails();
								accounts.Add(account);
								Console.WriteLine("number of accounts reg" + accounts.Count);
								break;
							case LOGIN:
								Console.WriteLine("Logged in");
								username = UserInterface.GetInput("Username");
								password = UserInterface.GetPassword("Password");
								for (int i = 0; i < accounts.Count; i++)
								{
									if (accounts[i].checkLogin(username, password))
									{
										Console.WriteLine("Welcome, {0} to aldiEbay", accounts[i].getFullname());
										accountID = i;
										running = 2;
									}
								}
								break;
							case EXIT:
								running = 0;
								break;
							default: break;
						}
						break;
					case 2:
						 option = UserInterface.GetOption("Select one of the options",
					"Register my item for sale", "List my items", "Search for items", "Place a bid on an item", "List bids received for my items", "Sell one of my item to highest bidder", "logout");
						switch (option)
                        {
                            case REGISTER_ITEM:
								string type, description;
								double inital;
								Product product = new Product();
								type = UserInterface.GetInput("Type");
								product.setType(type);
								description = UserInterface.GetInput("description");
								product.setDescription(description);
								inital = UserInterface.GetDouble("Inital price",0,100000);
								product.setInital(inital);
								product.setOwnerID(accountID);
								product.printDetails();
								products.Add(product);
								Console.WriteLine("number of accounts reg" + accounts.Count);
								Console.WriteLine("hello");
                                break;
							case LIST:
								Console.WriteLine("Products list");
								getProductsByUser(accountID);
								break;
							case SEARCH:
								break;
							case PLACE_BID:
								break;
							case LIST_BID:
								break;
							case SELL_BID:
								break;
							case LOGOUT:
								running = 1;
								break;
							default: break;


						}


						break;
					default: break;
				}

			}
				
		}

		private static void getProductsByUser(int accountID)
        {
			for (int i = 0; i < products.Count; i++)
            {
				if(products[i].getOwnerID()  == accountID)
                {
					Console.WriteLine(products[i]);
                }
            }
        }
	}
}
