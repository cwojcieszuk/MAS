namespace MP4.Subset;

public class FootballPlayer
{
    public string Name { get; set; }
    public string Position { get; set; }

    public Team Team { get; set; }

    public FootballPlayer(string name, string position)
    {
        Name = name;
        Position = position;
    }

    public override string ToString()
    {
        return $"Name: {Name} Position: {Position}";
    }
}