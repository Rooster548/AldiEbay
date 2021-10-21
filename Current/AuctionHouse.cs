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
		Product product = new Product("Shirt", "a small t-shirt", 10.5, 1);
		product.placeBid(15, 0);
		product.placeBid(25, 2);
		addProduct(product);

	}
	public void  addProduct(Product product)
    {
		products.Add(product);
		
    }
	public void addAccount(Account account)
    {
		accounts.Add(account);
    }
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
	public List<Product> getProductsByUser(int accountID)
	{
		List<Product> tempProducts = new List<Product>();
		for (int i = 0; i < products.Count; i++)
		{
			if (products[i].getOwnerID() == accountID)
			{
				tempProducts.Add(products[i]);
			}
		}
		return tempProducts;
	}
	public Account getAccount(int accountID)
    {
		return accounts[accountID];
    }
	public List<Product> searchProductsByType(string query)
    {
		List<Product> tempProducts = new List<Product>();
		for (int i = 0; i < products.Count; i++)
		{
			if (products[i].getType().ToLower() == query.ToLower())
			{

				tempProducts.Add(products[i]);
			}
		}
		return tempProducts;
	}
}
