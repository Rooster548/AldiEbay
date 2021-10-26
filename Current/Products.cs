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


	public Product()
	{
		Console.WriteLine("A new account has been made");
		type = "MISC";
		description = "default description";
		Inital = 0;
	}
	public Product(string type,string description, double inital, int accountID, int productID)
    {
		Type = type;
		Description = description;
		Inital = inital;
		OwnerID = accountID;
		ProductID = productID;
    }
	public void printDetails()
	{
		Console.WriteLine("-------------");
		Console.WriteLine(type);
		Console.WriteLine(description);
		Console.WriteLine(inital);
		Console.WriteLine(ownerID);
		Console.WriteLine("-------------");
	}
	
    public override string ToString()
    {
        return type + ", " + description + ", $" + inital + " Current Bid $" + getMin() + "id" + productID ;
    }
	public bool placeBid(double bidAmount, string username, bool deliveryMethod)
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
		return false;
    }
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

	public string getFormattedBids()
    {
		string output = this.ToString();
		for (int i = 0; i < bids.Count; i++)
		{
			output += "\n    "+ bids[i];

		}
		return output;
	}
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

