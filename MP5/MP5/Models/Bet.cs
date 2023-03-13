namespace MP5.Models;

public class Bet
{
    public int IdBet { get; set; }
    public string Category { get; set; }
    public double Rate { get; set; }
    public string BetType { get; set; }
    
    public string? EventName { get; set; }
    public string? SportName { get; set; }

    public virtual ICollection<BetCoupon> BetCoupons { get; set; }
}