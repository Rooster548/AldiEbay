using System;
public class BidDelivery : Bid
{
    private const double DELIVERY_TAX_DELTA = 5;
    public BidDelivery(double bidAmount, string username) : base(bidAmount, username)
    {

    }

    public override double getFees()
    {
        return 20;
    }
    public override double getTax()
    {
        return base.getTax() + DELIVERY_TAX_DELTA;
    }
}
