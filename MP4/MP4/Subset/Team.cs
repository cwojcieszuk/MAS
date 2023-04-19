namespace MP4.Subset;

public class Team
{
    public string Name { get; set; }
    public string League { get; set; }
    private FootballPlayer _teamCaptain { get; set; }

    public FootballPlayer TeamCaptain { get => _teamCaptain; set => SetTeamCaptain(value); }

    private List<FootballPlayer> _footballPlayers = new ();

    public Team(string name, string league)
    {
        Name = name;
        League = league;
    }

    public void AddPlayer(FootballPlayer player)
    {
        if (_footballPlayers.Contains(player)) return;

        _footballPlayers.Add(player);
        player.AddTeam(this);
    }

    public void SetTeamCaptain(FootballPlayer player)
    {
        if (!_footballPlayers.Contains(player))
        {
            throw new Exception("This football player is not connected with this team");
        }

        _teamCaptain = player;
    }

    public void ShowPlayers()
    {
        foreach (var player in _footballPlayers)
        {
            Console.WriteLine(player);
        }
    }

    public override string ToString()
    {
        return $"Name: {Name} League: {League} {(TeamCaptain is null ? "" : $"Team captain: {TeamCaptain}")}";
    }
}