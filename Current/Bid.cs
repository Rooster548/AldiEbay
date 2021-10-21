using System;

public class Bid
{
	private double bidAmount;
	private int accountID;
	public Bid()
	{
	}
	public Bid(double bidAmount, int accountID)
    {
		this.bidAmount = bidAmount;
		this.accountID = accountID;
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
		return "user " + accountID + " has bid $" + bidAmount;
	}
}
