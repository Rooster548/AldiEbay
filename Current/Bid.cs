using System;

public class Bid
{
	
	
	private const double TAX = 0.15;
	protected double bidAmount;
	public double BidAmount
	{
		get { return bidAmount; }
		set { bidAmount = value; }
	}
	private string username;
	public string Username
    {
        get { return username; }
    }
	public Bid(double bidAmount, string username)
    {
		this.bidAmount = bidAmount;
		this.username = username;
    }
	/// <summary>
	/// Gets the static AuctionHouse fees depend on wether if it's home delivery or click and collect.
	/// </summary>
	/// <returns> returns a double containing the fees</returns>

	public virtual double getFees() //
	{
		return 10;
	}
	/// <summary>
	/// Gets the  tax depend on wether if it's home delivery or click and collect.
	/// </summary>
	/// <returns> returns a double containing the tax</returns>
	public virtual double getTax() // 
	{
		return Math.Round ( bidAmount * TAX,2);

	}
	/// <summary>
	/// ToString used to return the amount a user has bid.
	/// </summary>
	/// <returns>Returns a string  representing the amount a user has bid</returns>
	public override string ToString()
	{
		return "  " + username + " has bid $" + bidAmount;
	}

	

	
}

