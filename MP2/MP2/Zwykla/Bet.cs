namespace MP2.Z_Atrybutem;

public class Bet
{
    public DateTime Date { get; set; }
    public int Amount { get; set; }
    public Player Player { get; set; }

    public Bet(DateTime date, int amount)
    {
        Date = date;
        Amount = amount;
    }

    public override string ToString()
    {
        return base.ToString() + $": Date: {Date} Amount: {Amount}";
    }
}