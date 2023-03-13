namespace MP5.Models;

public class PlayerCoupon
{
    public double Amount { get; set; }
    public int IdPlayer { get; set; }
    public int IdCoupon { get; set; }
    public virtual Player Player { get; set; }
    public virtual Coupon Coupon { get; set; }
}