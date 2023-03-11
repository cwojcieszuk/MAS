namespace MP2.Z_atrybutem;

public class Contract
{
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }

    public BallPlayer BallPlayer { get; set; }
    public Team Team { get; set; }

    public Contract(DateTime dateFrom, DateTime dateTo, BallPlayer ballPlayer, Team team)
    {
        DateFrom = dateFrom;
        DateTo = dateTo;
        BallPlayer = ballPlayer;
        Team = team;
        
        ballPlayer.AddContract(this);
        team.AddContract(this);
    }

    public override string ToString()
    {
        return base.ToString() + $" Date from: {DateFrom.ToString("yyyy MMMM dd")} Date to: {DateTo.ToString("yyyy MMMM dd")}";
    }
}