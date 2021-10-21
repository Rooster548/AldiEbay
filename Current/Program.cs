using System;
using System.Collections.Generic;
using System.IO;

using CAB201;

namespace UserInterfaceDemo {
	/// <summary>
	/// Demonstration program for UserInterface class.
	/// </summary>
	public class Program {
		static void Main( string[] args ) {
			MainMenu();
		}

		/// <summary>
		/// Displays a menu allowing user to choose an input operation to test.
		/// When user selects 4, program terminates.
		/// </summary>
		static void MainMenu() {
			AuctionHouse ah = new AuctionHouse();
			const int REGISTER_ACCOUNT = 0, LOGIN = 1, EXIT = 2;
			const int REGISTER_ITEM = 0, LIST = 1, SEARCH = 2, PLACE_BID = 3, LIST_BID = 4, SELL_BID = 5, LOGOUT = 6;
			int option;
			///const int READ_INT = 0, READ_DOUBLE = 1, READ_BOOL = 2, GET_PASSWORD = 3, EXIT = 4;

			Console.WriteLine( "Welcome to the UserInterface Demo program." );
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
								ah.addAccount(account);

								break;
							case LOGIN:
								Console.WriteLine("Logged in");
								username = UserInterface.GetInput("Username");
								password = UserInterface.GetPassword("Password");
								accountID = ah.checkLogin(username, password);
								if (accountID != -1)
                                {
									running = 2;
									Console.WriteLine("Welcome, {0} to aldiEbay", ah.getAccount(accountID).getFullname());
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
								ah.addProduct(product);
								Console.WriteLine("hello");
                                break;
							case LIST:
								Console.WriteLine("Products list");
								List<Product> productsByUser =  ah.getProductsByUser(accountID);
								printProducts(productsByUser);
								break;
							case SEARCH:
								string query = UserInterface.GetInput("Type");
								List<Product> productsByType = ah.searchProductsByType(query);
								printProducts(productsByType);
								break;
							case PLACE_BID:
								string query2 = UserInterface.GetInput("Type");
								List<Product> productsByType2 = ah.searchProductsByType(query2);
								Console.WriteLine("Choose one of the following products:");
								printProducts(productsByType2);
								int productIndex = UserInterface.GetInt("Index:",0,productsByType2.Count)-1;
								Product bidProduct = productsByType2[productIndex];
								double bidAmount = UserInterface.GetDouble("Enter bid $",bidProduct.getMin(),Double.PositiveInfinity);
								bool deliveryMethod = UserInterface.GetBool("Home Delivery");
                                if (deliveryMethod)
                                {

                                }
                                else
                                {
									bidProduct.placeBid(bidAmount, accountID);
                                }
								break;
							case LIST_BID:
								List<Product> productsByUser2 = ah.getProductsByUser(accountID);
								for (int i = 0; i < productsByUser2.Count; i++)
								{
									Console.WriteLine((i + 1) + ") " + productsByUser2[i].getFormattedBids());
								}
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
		private static void printProducts(List<Product> list)
		{
			for (int i = 0; i < list.Count; i++)
			{
				Console.WriteLine((i+1)+") " + list[i]);
			}
		}
	}
	
}
