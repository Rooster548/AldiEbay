using System;
using System.Collections.Generic;

public class AuctionHouse
{
	private static List<Account> accounts = new List<Account>();
	private static List<Product> products = new List<Product>();
	public AuctionHouse()
	{
		addAccount(new Account("Matt", "pass"));
		addAccount(new Account("Ryan", "pass"));
		addAccount(new Account("Ethan", "pass"));
		Product product = new Product("Shirt", "a small t-shirt", 10.5, 1,0);
		product.placeBid(15, "Matt",true);
		product.placeBid(25, "Ethan",false);
		addProduct(product);
		Product product1 = new Product("Shirt", "a med t-shirt", 10.5, 1,1);
		product1.placeBid(15, "Matt", false);
		product1.placeBid(25, "Ethan", true);
		addProduct(product1);
		Product product2 = new Product("Shirt", "a big t-shirt", 10.5, 0, 2);
		addProduct(product2);



	
	}
	/// <summary>
	/// Adds a new product from the user.
	/// </summary>
	/// <param name="product">Allows for a new product to be added</param>
	public void  addProduct(Product product)
    {
		product.ProductID = products.Count;
		products.Add(product);
		
    }
	/// <summary>
	/// Adds a new account that can be logged into
	/// </summary>
	/// <param name="account">Allows for a new account to be added</param>
	public void addAccount(Account account)
    {
		accounts.Add(account);
    }
	/// <summary>
	/// Checks the login information of the user through string username and password.
	/// </summary>
	/// <param name="username">Username for an existing account.</param>
	/// <param name="password">Password for an existing account</param>
	/// <returns>Returns I if the information is correct and proceeds to the program. Returns -1 if incorrect. </returns>
	public int checkLogin(string username, string password)
    {
		for (int i = 0; i < accounts.Count; i++)
		{
			if (accounts[i].checkLogin(username, password))
			{
				return i;
			}
		}
		return -1;
		
	}
	/// <summary>
	/// Creates a list of all the products owned by a user.
	/// </summary>
	/// <param name="accountID">is the unique accountID for a user</param>
	/// <returns>Returns a list of products the user owns</returns>
	public List<Product> getProductsByUser(int accountID)
	{
		List<Product> tempProducts = new List<Product>();
		for (int i = 0; i < products.Count; i++)
		{
			///If the userID matches the provided ID.
			if (products[i].OwnerID == accountID)
			{
				///Then add it to the list
				tempProducts.Add(products[i]);
			}
		}
		return tempProducts;
	}
	/// <summary>
	/// Returns the account with the provided ID
	/// </summary>
	
	public Account getAccount(int accountID)
    {
		return accounts[accountID];
    }
	/// <summary>
	/// Allows the user to search for a product and shows a list of matched products
	/// </summary>
	/// <param name="query">Represents the input of the user.</param>
	/// <returns>Returns a list of products that match the query</returns>
	public List<Product> searchProductsByType(string query)
    {
		List<Product> tempProducts = new List<Product>();
		for (int i = 0; i < products.Count; i++)
		{
			///Check if the type matches the provided query
			if (products[i].Type.ToLower() == query.ToLower())
			{
				///Then add the product to the list.
				tempProducts.Add(products[i]);
			}
		}
		return tempProducts;
	}
	/// <summary>
	///  A function that allows for an item be sold and then removed from the product list.
	/// </summary>
	/// <param name="productID">Represents the unique ID of a user.</param>
	/// <returns>Returns a string which all transaction information</returns>
	public string sellItem(int productID)
    {
		string output = products[productID].sellItem();
		products.RemoveAt(productID);
		return output;
	}
}
