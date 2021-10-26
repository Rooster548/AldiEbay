using System;
public class BidDelivery : Bid
{
    private const double DELIVERY_TAX_DELTA = 5;
    public BidDelivery(double bidAmount, string username) : base(bidAmount, username)
    {

    }
    /// <summary>
    /// Gets the static AuctionHouse fees depend on wether if it's home delivery or click and collect.
    /// </summary>
    /// <returns> returns a double containing the fees</returns>
    public override double getFees()
    {
        return 20;
    }
    /// <summary>
    /// Gets the  tax depend on wether if it's home delivery or click and collect.
    /// </summary>
    /// <returns> returns a double containing the tax</returns>
    public override double getTax()
    {
        return base.getTax() + DELIVERY_TAX_DELTA;
    }
}
