using MP5.Models;

namespace MP5.DTO;

public class GetCouponsByPlayerDTO
{
    public int PlayerId { get; set; }
    public int CouponId { get; set; }
    public double Amount { get; set; }
    public double FullRate { get; set; }
    public double PotentialWin { get; set; }
    public DateTime Date { get; set; }
    public IEnumerable<Bet> Bets { get; set; }
}