namespace MP5.Models;

public class Coupon
{
    public int IdCoupon { get; set; }
    public DateTime Date { get; set; }
    public double FullRate { get; set; }
    public double PotentialWin { get; set; }
    
    public virtual ICollection<PlayerCoupon> PlayerCoupons { get; set; }
    public virtual ICollection<BetCoupon> BetCoupons { get; set; }
}