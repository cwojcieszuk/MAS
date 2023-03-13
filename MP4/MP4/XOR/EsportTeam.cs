namespace MP4.XOR;

public class EsportTeam
{
    public string Name { get; set; }
    public string Game { get; set; }

    private List<Player> _players = new List<Player>();

    public EsportTeam(string name, string game)
    {
        Name = name;
        Game = game;
    }
    
    public void AddPlayer(Player player)
    {
        if (!_players.Contains(player))
        {
            _players.Add(player);
            
            player.AddEsportTeam(this);
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
        return $"Name: {Name} Game: {Game}";
    }
}