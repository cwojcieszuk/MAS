namespace MP2.Z_Atrybutem;

public class Player
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string BankAccount { get; set; }
    public string? Gender { get; set; }

    private List<Bet> _bets = new List<Bet>();
    
    public Player(string name, int age, string bankAccount, string gender = null)
    {
        Name = name;
        Age = age;
        BankAccount = bankAccount;
        Gender = gender;
    }
    
    public override string ToString()
    {
        string gender = Gender == null ? "" : $"gender: {Gender}";
        string bets = this._bets.Count <= 0 ? "" : $" Bets: {string.Join(", ", this._bets)}";
        return base.ToString() + $": Name: {Name} Age: {Age} {gender}{bets}";
    }

    public void AddBet(Bet bet)
    {
        if (!_bets.Contains(bet))
        {
            _bets.Add(bet);

            bet.Player = this;
        }
    }
}