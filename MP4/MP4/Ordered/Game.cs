using MP4.Utils;

namespace MP4.Ordered;

public class Game
{
    public string Name { get; set; }
    public string Studio { get; set; }

    private SortedSet<GamePlayer> _players = new SortedSet<GamePlayer>(new GamePlayerComparer());

    public Game(string name, string studio)
    {
        Name = name;
        Studio = studio;
    }

    public void ShowPlayers()
    {
        foreach (var player in _players)
        {
            Console.WriteLine(player.Name + " " + player.Game);
        }
    }

    public override string ToString()
    {
        return base.ToString() + $" Name: {Name} Studio: {Studio}";
    }

    public void AddPlayer(GamePlayer player)
    {
        if (!_players.Contains(player))
        {
            _players.Add(player);
            player.Game = this;
        }
    }
}