namespace MP4.XOR;

public class Player
{
    public string Name { get; set; }
    private BallTeam _ballTeam {  get; set; }
    private EsportTeam _esportTeam { get; set; }

    public BallTeam BallTeam { get => _ballTeam; set => AddBallTeam(value); }
    public EsportTeam EsportTeam { get => _esportTeam; set => AddEsportTeam(value); }

    public Player(string name)
    {
        Name = name;
    }

    public void AddBallTeam(BallTeam ballTeam)
    {
        if (EsportTeam is null)
        {
            _ballTeam = ballTeam;
            ballTeam.AddPlayer(this);
        }
        else
        {
            throw new Exception("You cant add player to ball team because he is already in esport team");
        }
    }

    public void AddEsportTeam(EsportTeam esportTeam)
    {
        if (BallTeam is null)
        {
            _esportTeam = esportTeam;
            esportTeam.AddPlayer(this);
        }
        else
        {
            throw new Exception("You cant add player to esport team because he is already in ball team");
        }
    }

    public override string ToString()
    {
        string esportTeam = EsportTeam is null ? "" : $"Esport team: {EsportTeam}";
        string ballTeam = BallTeam is null ? "" : $"Ball team: {BallTeam}";
        return $"Name: {Name} {ballTeam} {esportTeam}";
    }
}