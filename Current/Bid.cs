using System;

public class Bid
{
	protected double bidAmount;
	private string username;
	private const double tax = 0.15;
	public Bid()
	{
	}
	public Bid(double bidAmount, string username)
    {
		this.bidAmount = bidAmount;
		this.username = username;
    }
	public void setBidAmount(double bidAmount)
    {
		if (bidAmount >= 0)
        {
			this.bidAmount = bidAmount;
        }

    }
	public double getBidAmount()
    {
		return this.bidAmount;
    }
	public override string ToString()
	{
		return "  " + username + " has bid $" + bidAmount;
	}

	public string getName()
    {
		return this.username;	
    }

	public virtual double getFees()
	{
		return 10;
	}
	public virtual double getTax()
    {
		return bidAmount * tax;

	}
}

