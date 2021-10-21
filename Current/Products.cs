using System;
using System.Collections.Generic;

public class Product
{
	private string type, description;
	private double inital;
	private int ownerID;
	List<Bid> bids = new List<Bid>();


	public Product()
	{
		Console.WriteLine("A new account has been made");
		type = "MISC";
		description = "default description";
		inital = 0;
	}
	public Product(string type,string description, double inital, int accountID)
    {
		this.type = type;
		this.description = description;
		this.inital = inital;
		this.ownerID = accountID;
    }
	public Boolean setType(string type)
	{
		if (!String.IsNullOrEmpty(type))
		{
			this.type = type;
			return true;
		}
		return false;
	}
	public Boolean setDescription(string description)
	{
		if (!String.IsNullOrEmpty(description))
		{
			this.description = description;
			return true;
		}
		return false;
	}
	public Boolean setInital(double inital)
	{
		if (inital >= 0)
		{
			this.inital = inital;
			return true;
		}
		return false;
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
	public void setOwnerID(int ownerID)
    {
		this.ownerID = ownerID;


    }
	public int getOwnerID()
    {
		return this.ownerID;
    }
	public string getType()
    {
		return this.type;
    }
    public override string ToString()
    {
        return type + ", " + description + ", $" + inital;
    }
	public bool placeBid(double bidAmount, int accountID)
    {
		Bid bid = new Bid(bidAmount,accountID);
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
			return bids[bids.Count - 1].getBidAmount();
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
}

