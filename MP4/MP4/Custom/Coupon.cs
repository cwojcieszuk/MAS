namespace MP4.Custom;

public class Coupon
{
    public string Category { get; set; }
    public DateTime Date { get; set; }
    public CouponStatus Status { get; set; }

    private static List<Coupon> _coupons = new List<Coupon>();

    public Coupon(string category, DateTime date, CouponStatus status)
    {
        Category = category;
        Date = date;
        Status = status;
        
        AddCoupon(this);
    }

    public static void ShowCoupons()
    {
        foreach (var coupon in _coupons)
        {
            Console.WriteLine(coupon);
        }
    }

    public override string ToString()
    {
        return $"Category: {Category} Date: {Date} Status: {Status}";
    }

    private static void AddCoupon(Coupon coupon)
    {
        if (!_coupons.Contains(coupon))
        {
            _coupons.Add(coupon);
        }
    }

    private static void RemoveCoupon(Coupon coupon)
    {
        _coupons.Remove(coupon);
    }
}