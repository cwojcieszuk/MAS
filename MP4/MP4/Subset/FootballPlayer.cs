namespace MP4.Subset;

public class FootballPlayer
{
    public string Name { get; set; }
    public string Position { get; set; }

    private Team _team { get; set; }
    public Team Team { get => _team;
        set => AddTeam(value);
    }

    public FootballPlayer(string name, string position)
    {
        Name = name;
        Position = position;
    }

    public void AddTeam(Team team)
    {
        _team = team;
        team.AddPlayer(this);
    }

    public override string ToString()
    {
        return $"Name: {Name} Position: {Position}";
    }
}