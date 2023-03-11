namespace MP2.Z_atrybutem;

public class Team
{
    public string Name { get; set; }

    private List<Contract> _contracts = new List<Contract>();

    public Team(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return base.ToString() + $" Name: {Name}";
    }

    public void ShowPlayers()
    {
        Console.WriteLine(this + $" Players:");
        foreach (var contract in _contracts)
        {
            Console.WriteLine($"{contract.BallPlayer} {contract}");
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