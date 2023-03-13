using MP4.Utils;

namespace MP4.Ordered;

public class Game
{
    public string Name { get; set; }
    public string Studio { get; set; }

    private static SortedSet<Game> _games = new SortedSet<Game>(new GameComparer());

    public Game(string name, string studio)
    {
        Name = name;
        Studio = studio;
        
        AddGame(this);
    }

    public static void ShowGames()
    {
        foreach (var game in _games)
        {
            Console.WriteLine(game);
        }
    }

    public override string ToString()
    {
        return base.ToString() + $" Name: {Name} Studio: {Studio}";
    }

    private void AddGame(Game game)
    {
        if (!_games.Contains(game))
        {
            _games.Add(game);
        }
    }
}