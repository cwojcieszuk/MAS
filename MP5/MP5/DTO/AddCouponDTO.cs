namespace MP5.DTO;

public class AddCouponDTO
{
    public int IdPlayer { get; set; }
    public double Amount { get; set; }
    public int[] BetIds { get; set; }
}