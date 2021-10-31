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
			AuctionHouse ah = new AuctionHouse(); // Makes auctionhouse abstract
			///Setting up all the constants///
			const int REGISTER_ACCOUNT = 0, LOGIN = 1, EXIT = 2;
			const int REGISTER_ITEM = 0, LIST = 1, SEARCH = 2, PLACE_BID = 3, LIST_BID = 4, SELL_BID = 5, LOGOUT = 6;
			const int QUIT = 0, REGISTER_LOGIN = 1, MAIN_MENU = 2;
			int option;
			int running = REGISTER_LOGIN; /// Set running to 1.
			int accountID = -1; /// Sets a default value for accountID (-1 means that no one is logged in)
			while (running > QUIT)
			{
				switch (running)
				{
					case 0:

						break;

					case 1:
						///Shows the first menu to the user
						 option = UserInterface.GetOption("Select one of the options",
					"Register", "Login", "Exit" 
				);
						
						switch (option)
						{
							case REGISTER_ACCOUNT:
								/// Set up the variables to hold the users information.
								string fullName, username, password, address;

								/// Create a new account, that the variables can be assigned to.
								Account account = new Account();

								/// Collect all the details from the user
								fullName = UserInterface.GetInput("Full name");
								account.Fullname = fullName;
								username = UserInterface.GetInput("Username");
								account.Username = username;
								password = UserInterface.GetPassword("Password");
								account.Password = password;
								address = UserInterface.GetInput("Address");
								account.Address = address;

								///Adds the account to the list
								ah.addAccount(account);

								break;
							case LOGIN:
								/// Gets the inputs from the user.
								username = UserInterface.GetInput("Username");
								password = UserInterface.GetPassword("Password");

								///Checks if there is a valid account with matching details.
								accountID = ah.checkLogin(username, password);

								/// If there is a matching account 
								if (accountID != -1)
                                {
									///Sets the running state to main menu
									running = MAIN_MENU;
									///Present the user with a welcome message
									Console.WriteLine("Welcome, {0} to aldiEbay", ah.getAccount(accountID).Username);
                                }
								break;
							case EXIT:
								///Sets the running state to quit
								running = QUIT;
								break;
							default: break;
						}
						break;
					case MAIN_MENU:
						
						///Shows the main menu to the user once they have logged in
						option = UserInterface.GetOption("Select one of the options",
					"Register my item for sale", "List my items", "Search for items", "Place a bid on an item", "List bids received for my items", "Sell one of my item to highest bidder", "logout");
						Console.Write("\n");
						switch (option)
						{
							case REGISTER_ITEM:
								///Sets up the variables to hold the product information
								string type, description;
								double inital;

								/// Create a new product, that the variables can be assigned to.
								Product product = new Product();

								/// Collect all the details from the user
								type = UserInterface.GetInput("Type");
								product.Type = type;
								description = UserInterface.GetInput("description");
								product.Description = description;
								inital = UserInterface.GetDouble("Inital price", 0, Double.PositiveInfinity);
								product.Inital = inital;
								product.OwnerID = accountID; /// We already know the accountID since they have logged in

								///Adds the product to the list of products
								ah.addProduct(product);
								break;
							case LIST:
								///Lists the products owned by the user thats logged in.
								Console.WriteLine("Products list");
								List<Product> productsByUser = ah.getProductsByUser(accountID);
								printProducts(productsByUser);
								break;
							case SEARCH:
								///Lists the products that have a type matching the user query.
								string query = UserInterface.GetInput("Type");
								List<Product> productsByType = ah.searchProductsByType(query);
								printProducts(productsByType);
								break;
							case PLACE_BID:
								///Before a bid can be placed an item has to be chosen.
								///Allow the user to search by type.
								string query2 = UserInterface.GetInput("Type");
								List<Product> productsByType2 = ah.searchProductsByType(query2);
								Console.WriteLine("Choose one of the following products:");
								///Let them choose one of the matching products.
								printProducts(productsByType2);
								int productIndex = UserInterface.GetInt("Index:", 0, productsByType2.Count) - 1;
								///Store the chosen product in "bidProduct"
								Product bidProduct = productsByType2[productIndex];
								///Ask the user for a bid that is greater than the previous highest bid.
								double bidAmount = UserInterface.GetDouble("Enter bid $", bidProduct.getMin(), Double.PositiveInfinity);
								///Ask the user if they want home delivery.
								bool deliveryMethod = UserInterface.GetBool("Home Delivery(true/false)");
								///places the bid on the product
								bidProduct.placeBid(bidAmount, ah.getAccount(accountID).Username, deliveryMethod);
								break;
							case LIST_BID:
								///Gets all the products that a user owns
								List<Product> productsByUser2 = ah.getProductsByUser(accountID);
								for (int i = 0; i < productsByUser2.Count; i++)
								{
									///List each product along with its bids.
									Console.WriteLine((i + 1) + ") " + productsByUser2[i].getFormattedBids());
								}
								break;
							case SELL_BID:
								///Get all the products that a user owns
								List<Product> productsByUser3 = ah.getProductsByUser(accountID);
								for (int i = 0; i < productsByUser3.Count; i++)
								{
									///List each product along with its bid.
									Console.WriteLine((i + 1) + ") " + productsByUser3[i].getFormattedBids());
								}
								///Asks the user to choose a product.
								int productNumber = UserInterface.GetInt("Enter a product number", 0, productsByUser3.Count) - 1;
								///Convert local productNumber into the actual productID
								int actualProductID = productsByUser3[productNumber].ProductID;
								///Print the details of the transaction.
								Console.WriteLine(ah.sellItem(actualProductID));


								break;
							case LOGOUT:
								running = REGISTER_LOGIN; /// exits back to the first menu
								accountID = -1; /// Sets it back to negative one to represent no one is logged in
								break;
							default: break;


						}
						Console.Write("\n");


						break;
					default: break;
				}

			}

			
		}
		/// <summary>
		/// Prints a list of products
		/// </summary>
		/// <param name="list">The list to be printed</param>
		private static void printProducts(List<Product> list)
		{
			for (int i = 0; i < list.Count; i++)
			{
				Console.WriteLine((i+1)+") " + list[i]);
			}
		}
	}
	
}
