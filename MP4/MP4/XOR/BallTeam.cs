namespace MP4.XOR;

public class BallTeam
{
    public string Name { get; set; }
    public string League { get; set; }
    private List<Player> _players = new List<Player>();

    public BallTeam(string name, string league)
    {
        Name = name;
        League = league;
    }

    public void AddPlayer(Player player)
    {
        if (!_players.Contains(player))
        {
            _players.Add(player);
            
            player.AddBallTeam(this);
        }
    }
    
    public void ShowPlayers()
    {
        foreach (var player in _players)
        {
            Console.WriteLine(player);
        }
    }

    public override string ToString()
    {
        return $"Name: {Name} League: {League}";
    }
}