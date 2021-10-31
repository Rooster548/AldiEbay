using System;
using System.Collections.Generic;

public class Product
{

	private int ownerID;
	public int OwnerID
    {
		get { return ownerID;}
		set { ownerID = value;}
    }
	private int productID;
	public int ProductID
	{
		get { return productID; }
		set { productID = value; }
	}
	private string type;
	public string Type
    {
        set { type = value; }
		get { return type; }
    }
    private string description;
	public string Description
    {
        set { description = value; }
		private get { return description; }
    }
	private double inital;
	public double Inital
    {
		set { inital = value; }
		private get { return inital; }
    }


	List<Bid> bids = new List<Bid>();

	/// <summary>
	/// Creates a new template product.
	/// </summary>
	/// <returns>Returns a new product</returns>
	public Product()
	{
		type = "MISC";
		description = "default description";
		Inital = 0;
	}
	/// <summary>
	/// Creates a new product with provided values
	/// </summary>
	/// <param name="type">Type of the product(Shirts,Pants)</param>
	/// <param name="description">Description of the product</param>
	/// <param name="inital">Inital value of the product</param>
	/// <param name="accountID">Sets the owner of the product</param>
	/// <param name="productID">Sets a unique ID for the product</param>
	/// <returns>Returns a product with provided values</returns>
	public Product(string type,string description, double inital, int accountID, int productID)
    {
		Type = type;
		Description = description;
		Inital = inital;
		OwnerID = accountID;
		ProductID = productID;
    }
	/// <summary>
	/// Prints all the details of the product
	/// </summary>
	public void printDetails()
	{
		Console.WriteLine("-------------");
		Console.WriteLine(type);
		Console.WriteLine(description);
		Console.WriteLine(inital);
		Console.WriteLine(ownerID);
		Console.WriteLine("-------------");
	}

	/// <summary>
	/// ToString used to return the product information.
	/// </summary>
	/// <returns>Returns a string  representing a product</returns>
	public override string ToString()
    {
		return type + ", " + description + ", $" + inital + " Current Bid $" + getMin();
    }
	/// <summary>
	/// Creates the method for the user to place a bid on the current product
	/// </summary>
	/// <param name="bidAmount">Amount of the bid the user is placing</param>
	/// <param name="username">Username of the person who bid</param>
	/// <param name="deliveryMethod">Sets if its home delivery or click n collect (true means delivery, false means click n collect)</param>
	public void placeBid(double bidAmount, string username, bool deliveryMethod)
    {
		Bid bid;
        if (deliveryMethod)
        {
			bid = new BidDelivery(bidAmount, username);
        }
        else
        {
			bid = new Bid(bidAmount, username);
		}
		bids.Add(bid);
    }
	/// <summary>
	/// Gets a validated floating point between the designated lower and upper bounds.
	/// </summary>
	/// <returns>Returns the minimum allowed new bid</returns>
	public double getMin()
    {
		if (bids.Count == 0)
		{
			return inital;
		}
        else
        {
			return bids[bids.Count - 1].BidAmount;
        }
		

    }
	/// <summary>
	/// Uses a for loop to list all of the new bids made on a product.
	/// </summary>
	/// <returns>returns formatted list of bids made on a product</returns>
	public string getFormattedBids()
    {
		string output = this.ToString();
		for (int i = 0; i < bids.Count; i++)
		{
			output += "\n    "+ bids[i];

		}
		return output;
	}
	/// <summary>
	/// displays the information for when the item has been sold.
	/// </summary>
	/// <returns>returns all the information involved in selling the item.</returns>
	public string sellItem()
    {

		string output = "";
		output += bids[bids.Count - 1].Username;
		output += " Is the highest bider";
        output += "\nMoney sent to the auction house: $" + bids[bids.Count - 1].getFees();
		output += "\n Tax payable: $" + bids[bids.Count-1].getTax();

        return output;
    }
	
}

