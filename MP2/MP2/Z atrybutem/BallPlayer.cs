namespace MP2.Z_atrybutem;

public class BallPlayer
{
    public string Name { get; set; }
    public string Position { get; set; }

    private List<Contract> _contracts = new List<Contract>();

    public BallPlayer(string name, string position)
    {
        Name = name;
        Position = position;
    }

    public override string ToString()
    {
        return base.ToString() + $" Name: {Name} Position: {Position}";
    }

    public void ShowTeams()
    {
        Console.WriteLine(this + " Teams:");
        foreach (var contract in _contracts)
        {
            Console.WriteLine($"{contract.Team} {contract}");
        }
        Console.WriteLine();
    }
    
    public void AddContract(Contract contract)
    {
        if (!_contracts.Contains(contract))
        {
            _contracts.Add(contract);
        }
    }
}