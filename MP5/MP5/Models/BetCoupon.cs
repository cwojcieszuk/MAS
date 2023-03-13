namespace MP5.Models;

public class BetCoupon
{
    public int IdBet { get; set; }
    public int IdCoupon { get; set; }
    public virtual Bet Bet { get; set; }
    public virtual Coupon Coupon { get; set; }
}